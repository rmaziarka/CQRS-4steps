using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CQRS_step3.Domain.ProductsManagememt.Models;
using CQRS_step3.Domain.Store.Models;
using CQRS_step3.Domain.Store.Queries;
using Dapper;
using MediatR;

namespace CQRS_step3.Domain.Store.QueryHandlers
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<ProductReadModel>>
    {
        private readonly SqlConnection _sqlConnection;
        private readonly Dictionary<SortColumn, string> _sortColumnDict = new Dictionary<SortColumn, string>()
        {
            [SortColumn.ReviewCount] = "JSON_VALUE(Review, '$.Count') ",
            [SortColumn.ReviewAverage] = "JSON_VALUE(Review, '$.Average') ",
            [SortColumn.OrderAmount] = "OrderAmount "
        };

        public GetProductsQueryHandler(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        IEnumerable<ProductReadModel> IRequestHandler<GetProductsQuery, IEnumerable<ProductReadModel>>.Handle(GetProductsQuery command)
        {
            var builder = new SqlBuilder();

            // template
            var selector = builder.AddTemplate(
                @"SELECT * FROM Products /**where**/ /**orderby**/
	            OFFSET @Take * (@Page - 1) ROWS
	            FETCH NEXT @Take ROWS ONLY; ");
            builder.AddParameters(new { command.Page, command.Take });

            // filtering - rating
            if (command.AtLeastRating.HasValue)
            {
                builder.Where("JSON_VALUE(Review,'$.Average') >= @AtLeastRating", command);
            }

            // filtering - field values
            foreach (var fieldValue in command.FieldValues)
            {
                var path = $"$.\"{fieldValue.Key}\""; // 1 => $."1"
                builder.Where(@"JSON_VALUE(FieldValues, @Path) = @Value", new { Path = path, Value = fieldValue.Value });
            }

            // ordering
            var orderBy = _sortColumnDict[command.SortColumn];
            orderBy += command.SortOrder == SortOrder.Ascending ? "ASC" : "DESC";
            builder.OrderBy(orderBy);

            // running SQL query
            var products = _sqlConnection.Query<ProductReadModel>(selector.RawSql, selector.Parameters);

            return products;
        }
    }
}