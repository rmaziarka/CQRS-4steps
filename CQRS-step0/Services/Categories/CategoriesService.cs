using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CQRS_step0.Models;

namespace CQRS_step0.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ProductDatabase _database;

        public CategoriesService(ProductDatabase database)
        {
            _database = database;
        }

        public void ChangeProductCategory(ChangeProductCategoryDto dto)
        {
            var product = _database.Products.First(p => p.Id == dto.ProductId);

            product.CategoryId = dto.CategoryId;

            _database.SaveChanges();
        }
    }
}