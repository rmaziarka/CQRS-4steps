using System.Linq;
using CQRS_step1.Models;
using MediatR;

namespace CQRS_step1.Domain.Categories
{
    public class ChangeProductCategoryCommandHandler:IRequestHandler<ChangeProductCategoryCommand>
    {
        private readonly ProductDatabase _database;

        public ChangeProductCategoryCommandHandler(ProductDatabase database)
        {
            _database = database;
        }

        public void Handle(ChangeProductCategoryCommand message)
        {
            var product = _database.Products.First(p => p.Id == message.ProductId);

            product.CategoryId = message.CategoryId;

            _database.SaveChanges();
        }
    }
}