namespace CQRS_step0.Services.Products
{
    public class ChangeProductFieldValueDto
    {
        public int ProductId { get; set; }

        public int FieldId { get; set; }

        public object FieldValue { get; set; }
    }
}