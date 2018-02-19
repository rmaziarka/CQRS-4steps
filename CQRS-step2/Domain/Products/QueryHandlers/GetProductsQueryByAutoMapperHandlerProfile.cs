using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CQRS_step2.Models;

namespace CQRS_step2.Domain.Products.QueryHandlers
{
    public class GetProductsQueryHandlerProfile : Profile
    {
        public GetProductsQueryHandlerProfile()
        {
            this.CreateMap<Product, ProductVm>()
                .ForMember(p => p.PictureUrl, m => m.MapFrom(p => p.Pictures.FirstOrDefault(pc => pc.IsMain).Picture.Url))
                .ForMember(p => p.ManufacturerMainPictureUrl, m => m.MapFrom(p => p.Manufacturer.Picture.Url))
                .ForMember(p => p.OrdersNumber, m => m.MapFrom(p => p.OrderItems.Count))
                .ForMember(p => p.AverageReviewRating, m => m.MapFrom(p => p.Reviews.Select(r => r.Rating).DefaultIfEmpty(0).Average()))
                .ForMember(p => p.LatestReviews, m => m.MapFrom(p => p.Reviews.OrderByDescending(r => r.CreateDate).Take(5)))
                .ForMember(p => p.BestDiscounts, m => m.MapFrom(p => p.Discounts.OrderByDescending(r => r.Value).Take(3)))
                ;

            this.CreateMap<RelatedProduct, RelatedProductVm>()
                .ForMember(p => p.PictureUrl, m => m.MapFrom(p => p.Product.Pictures.FirstOrDefault(pc => pc.IsMain).Picture.Url));

            this.CreateMap<FieldValue, FieldValueVm>();

            this.CreateMap<Review, ReviewVm>();

            this.CreateMap<Discount, DiscountVm>();
        }
    }
}