using System.Collections.Generic;
using CQRS_step0.Models;
using System.Linq;
using System.Data.Entity;

namespace CQRS_step0.Services.Products
{
    public class ProductsService: IProductsService
    {
        private readonly ProductDatabase _database;

        public ProductsService(ProductDatabase database)
        {
            _database = database;
        }

        public IEnumerable<Product> GetProducts(GetProductsDto dto)
        {
            return this._database
                .Products
                .Include(p => p.Category)
                .OrderBy(p => p.Id)
                .Skip((dto.Page - 1) * dto.Take)
                .Take(dto.Take)
                .ToList();
        }

        public void ChangeProductCategory(ChangeProductCategoryDto dto)
        {
            var product = _database.Products.First(p => p.Id == dto.ProductId);

            product.CategoryId = dto.CategoryId;

            _database.SaveChanges();
        }
    }
}