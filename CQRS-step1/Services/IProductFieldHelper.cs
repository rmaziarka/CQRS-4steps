using CQRS_step1.Models;

namespace CQRS_step1.Services
{
    public interface IProductFieldHelper
    {
        FieldValue AttachValueToField(Product product, int dtoFieldId, object dtoFieldValue);
        void ReplaceFieldValue(Product product, int dtoFieldId, object dtoFieldValue);
    }
}