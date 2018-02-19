using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CQRS_step1.Domain.Products.Query;
using CQRS_step1.Models;
using CQRS_step1.Services;
using MediatR;

namespace CQRS_step1.Domain.Products.QueryHandlers
{
    public class GetProductsQueryHandler: IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly ProductDatabase _database;

        public GetProductsQueryHandler(ProductDatabase database)
        {
            _database = database;
        }

        public IEnumerable<Product> Handle(GetProductsQuery message)
        {
            var products = this._database
                    .Products
                    .Include(p => p.Category)
                    .Include(p => p.FieldValues)
                    .Include(p => p.FieldValues.Select(fv => fv.Field))
                ;

            if (message.CategoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == message.CategoryId);
            }

            if (message.FieldValues != null)
            {
                var fieldIds = message.FieldValues.Select(fv => fv.Key).ToList();
                var fields = _database.Fields.Where(f => fieldIds.Contains(f.Id)).ToList();

                products = this.FilterFields(message.FieldValues, fields, products);
            }

            return products
                .OrderBy(p => p.Id)
                .Skip((message.Page - 1) * message.Take)
                .Take(message.Take)
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
                            && ((StringFieldValue)fv).StringValue == (string)fieldValue.Value));
                }
                else if (field is IntegerField)
                {
                    products = products.Where(
                        p => p.FieldValues.Any(fv =>
                            fv.FieldId == field.Id
                            && ((IntegerFieldValue)fv).IntegerValue == (int)fieldValue.Value));
                }
                // etc
            }
            return products;
        }
    }
}