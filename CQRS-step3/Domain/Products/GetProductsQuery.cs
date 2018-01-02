using System.Collections.Generic;
using CQRS_step3.Models;
using MediatR;

namespace CQRS_step3.Domain.Products
{
    public class GetProductsQuery: IRequest<IEnumerable<Product>>
    {
        public int Page { get; set; }

        public int Take { get; set; }
    }
}