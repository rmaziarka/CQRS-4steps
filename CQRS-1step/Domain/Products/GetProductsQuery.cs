using System.Collections.Generic;
using CQRS_1step.Models;
using MediatR;

namespace CQRS_1step.Domain.Products
{
    public class GetProductsQuery: IRequest<IEnumerable<Product>>
    {
        public int Page { get; set; }

        public int Take { get; set; }

        public int Skip { get; set; }
    }
}