namespace CQRS_step1.Services
{
    public interface IFieldValidatorFactory
    {
        IValidator GetValidator(int dtoFieldId);
    }
}