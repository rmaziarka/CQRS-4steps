using System.Collections.Generic;
using CQRS_step0.Models;
using System.Linq;
using System.Data.Entity;

namespace CQRS_step0.Services.Products
{
    public class ProductsService: IProductsService
    {
        private readonly ProductDatabase _database;
        private readonly ICategoryFieldService _categoryFieldService;
        private readonly IFieldValidatorFactory _fieldValidatorFactory;
        private readonly IProductFieldHelper _productFieldHelper;
        
        public ProductsService(ProductDatabase database, 
            ICategoryFieldService categoryFieldService, 
            IProductFieldHelper productFieldHelper, 
            IFieldValidatorFactory fieldValidatorFactory)
        {
            _database = database;
            _categoryFieldService = categoryFieldService;
            _productFieldHelper = productFieldHelper;
            _fieldValidatorFactory = fieldValidatorFactory;
        }

        public IEnumerable<Product> GetProducts(GetProductsDto dto)
        {
            var products = this._database
                    .Products
                    .Include(p => p.Category)
                    .Include(p => p.FieldValues)
                    .Include(p => p.FieldValues.Select(fv => fv.Field))
                ;

            if (dto.CategoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == dto.CategoryId);
            }

            if (dto.FieldValues != null)
            {
                var fieldIds = dto.FieldValues.Select(fv => fv.Key).ToList();
                var fields = _database.Fields.Where(f => fieldIds.Contains(f.Id)).ToList();

                products = this.FilterFields(dto.FieldValues, fields, products);
            }

            return products
                .OrderBy(p => p.Id)
                .Skip((dto.Page - 1) * dto.Take)
                .Take(dto.Take)
                .ToList();
        }

        private IQueryable<Product> FilterFields(Dictionary<int, object> fieldValues, List<Field> fields, IQueryable<Product> products)
        {
            foreach (var fieldValue in fieldValues)
            {
                var field = fields.First(f => f.Id == fieldValue.Key);

                if (field is StringField)
                {
                    products = products.Where(
                        p => p.FieldValues.Any(fv => 
                            fv.FieldId == field.Id 
                            && ((StringFieldValue) fv).StringValue == (string) fieldValue.Value));
                }
                else if (field is IntegerField)
                {
                    products = products.Where(
                        p => p.FieldValues.Any(fv => 
                            fv.FieldId == field.Id 
                            && ((IntegerFieldValue) fv).IntegerValue == (int) fieldValue.Value));
                }
                // etc
            }
            return products;
        }

        public void ChangeProductFieldValue(ChangeProductFieldValueDto dto)
        {
            this._categoryFieldService.ValidateIfFieldCanBeAssignedToProduct(dto.FieldId, dto.ProductId);

            var fieldValidator = this._fieldValidatorFactory(dto.FieldId);

            fieldValidator.Validate(dto.FieldValue);

            var product = this._database.Products
                .Include(p => p.FieldValues)
                .First(fv => fv.Id == dto.ProductId);

            var fieldValue = product.FieldValues.FirstOrDefault(fv => fv.FieldId == dto.FieldId);

            if (fieldValue == null)
            {
                this._productFieldHelper.AttachValueToField(product, dto.FieldId, dto.FieldValue);
            }
            else
            {
                this._productFieldHelper.ReplaceFieldValue(product, dto.FieldId, dto.FieldValue);
            }

            _database.SaveChanges();
        }
    }
}