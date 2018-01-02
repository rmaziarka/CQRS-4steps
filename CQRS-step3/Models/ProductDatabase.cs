using System.Collections.Generic;
using System.Data.Entity;

namespace CQRS_step3.Models
{
    public class ProductDatabase : DbContext
    {
        public ProductDatabase()
        {
            Database.SetInitializer(new ProductDatabaseInitializer());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }


    public class ProductDatabaseInitializer : DropCreateDatabaseAlways<ProductDatabase>
    {
        protected override void Seed(ProductDatabase context)
        {

            context.Categories.AddRange(
                new List<Category>()
                {
                    new Category()
                    {
                        Id = 1,
                        Name = "Electronics"
                    },
                    new Category()
                    {
                        Id = 2,
                        Name = "Fashion"
                    },
                    new Category()
                    {
                        Id = 3,
                        Name = "Sport"
                    },
                }
            );

            context.SaveChanges();

            context.Products.AddRange(new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Laptop"
                },
                new Product()
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "LCD"
                },
                new Product()
                {
                    Id = 3,
                    CategoryId = 2,
                    Name = "T-Shirt"
                },
                new Product()
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Jeans"
                },
                new Product()
                {
                    Id = 5,
                    CategoryId = 3,
                    Name = "Volleyball"
                },
                new Product()
                {
                    Id = 6,
                    CategoryId = 3,
                    Name = "Roller skates"
                },
            });
        }
    }
}