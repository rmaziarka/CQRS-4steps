using CQRS_step0.Models;

namespace CQRS_step0.Services.Fields
{
    public interface IProductFieldHelper
    {
        FieldValue AttachValueToField(Product product, int dtoFieldId, object dtoFieldValue);
        void ReplaceFieldValue(Product product, int dtoFieldId, object dtoFieldValue);
    }
}