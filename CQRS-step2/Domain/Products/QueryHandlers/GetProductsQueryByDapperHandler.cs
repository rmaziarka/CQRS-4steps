using System.Collections.Generic;
using System.Linq;
using CQRS_step2.Domain.Products.Query;
using CQRS_step2.Models;
using System.Data.Entity;
using System.Data.SqlClient;
using Dapper;
using MediatR;

namespace CQRS_step2.Domain.Products.QueryHandlers
{
    public class GetProductsQueryByDapperHandler : IRequestHandler<GetProductsByDapperQuery, IEnumerable<ProductVm>>
    {
        private readonly SqlConnection _connection;

        public GetProductsQueryByDapperHandler(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<ProductVm> Handle(GetProductsByDapperQuery command)
        {
            var sqlQuery = QueryHelper.GetQuery<GetProductsQueryByDapperHandler>();

            using (var multi = _connection.QueryMultiple(sqlQuery,
                new { command.Page, Take = command.Take, CategoryId = command.CategoryId }))
            {
                var products = multi.Read<ProductVm>().ToList();

                var relatedProducts = multi.Read<RelatedProductVm>().ToList();

                var latestReviews = multi.Read<ReviewVm>().ToList();

                var fieldValues = multi.Read<FieldValueVm>().ToList();

                var discounts = multi.Read<DiscountVm>().ToList();

                products.ForEach(p =>
                {
                    p.RelatedProducts = relatedProducts.Where(r => r.MainProductId == p.Id).ToList();
                    p.FieldValues = fieldValues.Where(r => r.ProductId == p.Id).ToList();
                    p.LatestReviews = latestReviews.Where(r => r.ProductId == p.Id).ToList();
                    p.BestDiscounts = discounts.Where(r => r.MainProductId == p.Id).ToList();
                });

                return products;
            }
        }
    }
}