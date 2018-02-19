using System.Collections.Generic;
using System.Linq;
using CQRS_step2.Domain.Products.Query;
using CQRS_step2.Models;
using System.Data.Entity;
using MediatR;
using AutoMapper.QueryableExtensions;

namespace CQRS_step2.Domain.Products.QueryHandlers
{
    public class GetProductsByAutoMapperQueryHandler : IRequestHandler<GetProductsByAutoMapperQuery, IEnumerable<ProductVm>>
    {
        private readonly ProductDatabase _database;

        public GetProductsByAutoMapperQueryHandler(ProductDatabase database)
        {
            _database = database;
        }

        public IEnumerable<ProductVm> Handle(GetProductsByAutoMapperQuery command)
        {
            IQueryable<Product> products = this._database.Products;

            if (command.CategoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == command.CategoryId);
            }

            return products
                .OrderBy(p => p.CreationDate)
                .Skip((command.Page - 1) * command.Take)
                .Take(command.Take)
                .ProjectTo<ProductVm>()
                .ToList();
        }
    }
}