namespace CQRS_step3.Domain.ProductsManagememt.Models
{
    public class FieldValue
    {
        public int FieldId { get; }

        public Field Field { get; }
    }

    public class IntegerFieldValue : FieldValue
    {
        public int IntegerValue { get; }
    }

    public class StringFieldValue : FieldValue
    {
        public string StringValue { get; }
    }

    // etc.
}