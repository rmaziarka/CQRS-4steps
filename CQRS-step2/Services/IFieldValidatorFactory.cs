namespace CQRS_step2.Services
{
    public interface IFieldValidatorFactory
    {
        IValidator GetValidator(int dtoFieldId);
    }
}