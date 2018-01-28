using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CQRS_step3.Domain.Orders.Models;
using CQRS_step3.Domain.ProductsManagememt.Models;
using CQRS_step3.Domain.Store.Models;

namespace CQRS_step3.Database
{
    public class CqrsDatabase : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<FieldValue> FieldValues { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ProductReadModel> ProductReadModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }

}