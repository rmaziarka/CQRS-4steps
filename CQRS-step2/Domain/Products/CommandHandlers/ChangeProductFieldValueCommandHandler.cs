using System.Data.Entity;
using System.Linq;
using CQRS_step2.Domain.Products.Commands;
using CQRS_step2.Models;
using CQRS_step2.Services;
using MediatR;

namespace CQRS_step2.Domain.Products.CommandHandlers
{
    public class ChangeProductFieldValueCommandHandler : IRequestHandler<ChangeProductFieldValueCommand, int>
    {
        private readonly ProductDatabase _database;
        private readonly ICategoryFieldService _categoryFieldService;
        private readonly IFieldValidatorFactory _fieldValidatorFactory;
        private readonly IProductFieldHelper _productFieldHelper;

        public ChangeProductFieldValueCommandHandler(ProductDatabase database,
            ICategoryFieldService categoryFieldService,
            IProductFieldHelper productFieldHelper,
            IFieldValidatorFactory fieldValidatorFactory)
        {
            _database = database;
            _categoryFieldService = categoryFieldService;
            _productFieldHelper = productFieldHelper;
            _fieldValidatorFactory = fieldValidatorFactory;
        }

        public int Handle(ChangeProductFieldValueCommand message)
        {
            this._categoryFieldService.ValidateIfFieldCanBeAssignedToProduct(message.FieldId, message.ProductId);

            var fieldValidator = this._fieldValidatorFactory.GetValidator(message.FieldId);

            fieldValidator.Validate(message.FieldValue);

            var product = this._database.Products
                .Include(p => p.FieldValues)
                .First(fv => fv.Id == message.ProductId);

            var fieldValue = product.FieldValues.FirstOrDefault(fv => fv.FieldId == message.FieldId);

            if (fieldValue == null)
            {
                fieldValue = this._productFieldHelper.AttachValueToField(product, message.FieldId, message.FieldValue);
            }
            else
            {
                this._productFieldHelper.ReplaceFieldValue(product, message.FieldId, message.FieldValue);
            }

            _database.SaveChanges();

            return fieldValue.Id;
        }
    }
}