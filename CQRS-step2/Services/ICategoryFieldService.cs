namespace CQRS_step2.Services
{
    public interface ICategoryFieldService
    {
        void ValidateIfFieldCanBeAssignedToProduct(int dtoFieldId, int dtoProductId);
    }
}