namespace CQRS_step0.Services.Products
{
    public interface ICategoryFieldService
    {
        void ValidateIfFieldCanBeAssignedToProduct(int dtoFieldId, int dtoProductId);
    }
}