using System.Collections.Generic;
using System.Data.Entity;
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
    }
}