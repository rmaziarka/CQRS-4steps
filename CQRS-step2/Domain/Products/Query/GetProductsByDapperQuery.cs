using System.Collections.Generic;
using CQRS_step2.Models;
using MediatR;

namespace CQRS_step2.Domain.Products.Query
{
    public class GetProductsByDapperQuery : IRequest<IEnumerable<ProductVm>>
    {
        public int Page { get; set; }

        public int Take { get; set; }

        public int? CategoryId { get; set; }
    }
}