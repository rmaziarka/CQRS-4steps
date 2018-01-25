using System.Collections.Generic;

namespace CQRS_step3.Domain.ProductsManagememt.Models
{
    public class Product
    {
        public Product(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public int CategoryId { get; private set; }

        public virtual Category Category { get; private set; }

        public virtual IEnumerable<Field> FieldValues  { get; private set; }
    }
}