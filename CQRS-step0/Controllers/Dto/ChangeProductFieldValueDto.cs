namespace CQRS_step0.Controllers.Dto
{
    public class ChangeProductFieldValueDto
    {
        public int FieldId { get; set; }
        public int ProductId { get; set; }
        public object FieldValue { get; set; }
    }
}