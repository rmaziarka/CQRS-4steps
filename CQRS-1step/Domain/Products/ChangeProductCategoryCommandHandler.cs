using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CQRS_1step.Models;
using MediatR;

namespace CQRS_1step.Domain.Products
{
    public class ChangeProductCategoryCommandHandler:IRequestHandler<ChangeProductCategoryCommand>
    {
        private readonly ProductDatabase _context;

        public ChangeProductCategoryCommandHandler(ProductDatabase context)
        {
            _context = context;
        }

        public void Handle(ChangeProductCategoryCommand message)
        {
            var product = _context.Products.First(p => p.Id == message.ProductId);

            product.CategoryId = message.CategoryId;

            _context.SaveChanges();
        }
    }
}