using System.Linq;
using CQRS_step1.Models;
using MediatR;

namespace CQRS_step1.Domain.Products
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