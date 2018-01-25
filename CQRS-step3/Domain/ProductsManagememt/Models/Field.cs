namespace CQRS_step3.Domain.ProductsManagememt.Models
{
    public class Field
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public int CategoryId { get; private set; }

        public virtual Category Category { get; private set; }

        public virtual FieldType FieldType { get; private set; }
    }

    public enum FieldType
    {
        String,
        Integer
    }
}