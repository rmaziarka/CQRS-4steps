using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using CQRS_step3.Models;
using MediatR;

namespace CQRS_step3.Domain.Products
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly ProductDatabase _database;

        public GetProductsQueryHandler(ProductDatabase database)
        {
            _database = database;
        }

        IEnumerable<Product> IRequestHandler<GetProductsQuery, IEnumerable<Product>>.Handle(GetProductsQuery command)
        {
            var products = this._database
                    .Products
                    .Include(p => p.Category)
                    .Include(p => p.Pictures)
                    .Include(p => p.Manufacturer)
                    .Include(p => p.Manufacturer.Picture)
                    .Include(p => p.RelatedProducts)
                    .Include(p => p.RelatedProducts.Select(rp => rp.Pictures))
                    .Include(p => p.OrderItems)
                    .Include(p => p.FieldValues)
                    .Include(p => p.FieldValues.Select(fv => fv.Field))
                    .Include(p => p.Reviews)
                    .Include(p => p.Reviews.Select(r => r.User))
                    .Include(p => p.Discounts)
                    .Include(p => p.Discounts.Select(d => d.Product))
                ;

            if (command.CategoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == command.CategoryId);
            }
            
            return products
                .OrderBy(p => p.CreationDate)
                .Skip((command.Page - 1) * command.Take)
                .Take(command.Take)
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

    public class ProductVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }

        public string MainPictureUrl { get; set; }

        public string ManufacturerName { get; set; }

        public string ManufacturerMainPictureUrl { get; set; }

        public List<RelatedProductVm> RelatedProducts { get; set; } = new List<RelatedProductVm>();

        public int OrdersNumber { get; set; }

        public List<FieldValueVm> FieldValues { get; set; } = new List<FieldValueVm>();

        public float AverageReviewRating { get; set; }

        public List<ReviewVm> LatestReviews { get; set; } = new List<ReviewVm>();

        public List<DiscountVm> BestDiscounts { get; set; } = new List<DiscountVm>();
    }

    public class RelatedProductVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MainPictureUrl { get; set; }
    }

    public class FieldValueVm
    {
        public string Name { get; set; }

        public object Value { get; set; }
    }

    public class ReviewVm
    {
        public string UserName { get; set; }

        public float Rating { get; set; }
    }

    public class DiscountVm
    {
        public float Value { get; set; }

        public string ProductName { get; set; }
    }

    public class GetProductsQueryHandlerProfile : Profile
    {
        public GetProductsQueryHandlerProfile()
        {
            this.CreateMap<Product, ProductVm>()
                .ForMember(p => p.MainPictureUrl, m => m.MapFrom(p => p.Pictures.Single(pc => pc.Main).Url))
                .ForMember(p => p.ManufacturerMainPictureUrl, m => m.MapFrom(p => p.Manufacturer.Picture.Url))
                .ForMember(p => p.OrdersNumber, m => m.MapFrom(p => p.OrderItems.Count()))
                .ForMember(p => p.AverageReviewRating, m => m.MapFrom(p => p.Ratings.Average()))
                .ForMember(p => p.LatestReviews, m => m.MapFrom(p => p.Reviews.OrderByDesc(r => r.CreateDate).Take(5)))
                .ForMember(p => p.BestDiscounts, m => m.MapFrom(p => p.Discounts.OrderByDesc(r => r.Value).Take(3)))
                ;
            this.CreateMap<Product, RelatedProduct>()
                .ForMember(p => p.MainPictureUrl, m => m.MapFrom(p => p.Pictures.Single(pc => pc.Main).Url));

            this.CreateMap<IntegerFieldValue, FieldValueVm>()
                .ForMember(f => f.Value, m => m.MapFrom(f => f.IntegerValue));

            this.CreateMap<StringFieldValue, FieldValueVm>()
                .ForMember(f => f.Value, m => m.MapFrom(f => f.StringValue));

            this.CreateMap<Review, ReviewVm>();

            this.CreateMap<Discount, DiscountVm>();
        }
    }
}