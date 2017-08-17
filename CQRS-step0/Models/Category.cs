using System.Collections.Generic;

namespace CQRS_step0.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Field> Fields { get; set; }
    }
}