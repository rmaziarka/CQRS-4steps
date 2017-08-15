using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CQRS_step1.Models;
using MediatR;

namespace CQRS_step1.Domain.Products
{
    public class GetProductsQueryHandler:IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly ProductDatabase _database;

        public GetProductsQueryHandler(ProductDatabase database)
        {
            _database = database;
        }

        IEnumerable<Product> IRequestHandler<GetProductsQuery, IEnumerable<Product>>.Handle(GetProductsQuery message)
        {
            return this._database
                .Products
                .Include(p => p.Category)
                .OrderBy(p => p.Id)
                .Skip((message.Page - 1) * message.Take)
                .Take(message.Take)
                .ToList();
        }
    }
}