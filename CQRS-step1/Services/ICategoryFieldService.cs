namespace CQRS_step1.Services
{
    public interface ICategoryFieldService
    {
        void ValidateIfFieldCanBeAssignedToProduct(int dtoFieldId, int dtoProductId);
    }
}