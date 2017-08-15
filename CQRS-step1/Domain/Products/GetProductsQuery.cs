using System.Collections.Generic;
using CQRS_step1.Models;
using MediatR;

namespace CQRS_step1.Domain.Products
{
    public class GetProductsQuery: IRequest<IEnumerable<Product>>
    {
        public int Page { get; set; }

        public int Take { get; set; }
    }
}