namespace CQRS_step0.Services.Categories
{
    public interface ICategoriesService
    {
        void ChangeProductCategory(ChangeProductCategoryDto dto);
    }
}