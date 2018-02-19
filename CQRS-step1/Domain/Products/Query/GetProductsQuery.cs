using System.Collections.Generic;
using CQRS_step1.Models;
using MediatR;

namespace CQRS_step1.Domain.Products.Query
{
    public class GetProductsQuery: IRequest<IEnumerable<Product>>
    {
        public int Page { get; set; }

        public int Take { get; set; }
        public int? CategoryId { get; set; }
        public Dictionary<int, object> FieldValues { get; set; }
    }
}