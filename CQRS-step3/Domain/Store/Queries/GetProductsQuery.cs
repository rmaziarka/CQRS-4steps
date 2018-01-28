using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CQRS_step3.Domain.Store.Models;
using MediatR;

namespace CQRS_step3.Domain.Store.Queries
{
    public class GetProductsQuery: IRequest<IEnumerable<ProductReadModel>>
    {
        public Dictionary<int, object> FieldValues { get; set; } = new Dictionary<int, object>();

        public float? AtLeastRating { get; set; }

        public SortOrder SortOrder { get; set; }

        public SortColumn SortColumn { get; set; }

        public int Take { get; set; }

        public int Page { get; set; }
    }

    public enum SortColumn
    {
        ReviewCount, ReviewAverage, OrderAmount
    }
}