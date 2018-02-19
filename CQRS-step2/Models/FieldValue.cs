namespace CQRS_step2.Models
{
    public class FieldValue
    {
        public int Id { get; set; }

        public int FieldId { get; set; }

        public Field Field { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int? IntegerValue { get; set; }

        public string StringValue { get; set; }
    }
}