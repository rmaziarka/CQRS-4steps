using System.Collections.Generic;

namespace CQRS_step3.Domain.ProductsManagememt.Models
{
    public class Product
    {
        public int Id { get; } 

        public string Name { get; }

        public int CategoryId { get; }

        public Category Category { get; }

        public IEnumerable<Field> FieldValues  { get; }
    }
}