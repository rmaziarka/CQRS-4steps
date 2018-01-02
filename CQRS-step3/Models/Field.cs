using System.Collections.Generic;

namespace CQRS_step3.Models
{
    public class Field
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public IEnumerable<ValidationRule> ValidationRules { get; set; }
    }

    public class IntegerField : Field { }

    public class StringField : Field { }

    // etc.
}