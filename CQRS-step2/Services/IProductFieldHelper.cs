using CQRS_step2.Models;

namespace CQRS_step2.Services
{
    public interface IProductFieldHelper
    {
        FieldValue AttachValueToField(Product product, int dtoFieldId, object dtoFieldValue);
        void ReplaceFieldValue(Product product, int dtoFieldId, object dtoFieldValue);
    }
}