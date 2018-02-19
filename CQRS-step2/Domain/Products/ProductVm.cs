using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_step2.Domain.Products
{
    public class ProductVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }

        public string PictureUrl { get; set; }

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

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string PictureUrl { get; set; }

        public int MainProductId { get; set; }
    }

    public class FieldValueVm
    {
        public string FieldName { get; set; }

        public string FieldType { get; set; }

        public string StringValue { get; set; }

        public int IntegerValue { get; set; }

        public int ProductId { get; set; }
    }

    public class ReviewVm
    {
        public string UserName { get; set; }

        public DateTime CreateDate { get; set; }

        public float Rating { get; set; }

        public int ProductId { get; set; }
    }

    public class DiscountVm
    {
        public float Value { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int MainProductId { get; set; }
    }
}