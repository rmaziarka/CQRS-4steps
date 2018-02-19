using System;
using System.Collections.Generic;

namespace CQRS_step2.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime CreationDate { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public virtual ICollection<FieldValue> FieldValues { get; set; }

        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public virtual ICollection<Discount> Discounts { get; set; }

        public virtual ICollection<RelatedProduct> RelatedProducts { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<ProductPicture> Pictures { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<RelatedProduct> ProductsRelatedTo { get; set; }
        public ICollection<Discount> DiscountsRelatedTo { get; set; }
    }
}