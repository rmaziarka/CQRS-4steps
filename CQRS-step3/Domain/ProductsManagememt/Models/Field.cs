namespace CQRS_step3.Domain.ProductsManagememt.Models
{
    public class Field
    {
        public int Id { get; }

        public string Name { get; }

        public int CategoryId { get; }

        public Category Category { get; }

        //public IEnumerable<ValidationRule> ValidationRules { get; }
    }

    public class IntegerField : Field { }

    public class StringField : Field { }

    // etc.
}