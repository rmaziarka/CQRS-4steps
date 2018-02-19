namespace CQRS_step0.Services.Fields
{
    public interface IFieldValidatorFactory
    {
        IValidator GetValidator(int dtoFieldId);
    }
}