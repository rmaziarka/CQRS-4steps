using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CQRS_step3.Events;

namespace CQRS_step3.Models
{
    public class ProductReadModel
    {
        public ProductReadModel(ProductAddedEvent @event)
        {
            Id = @event.Id;
            Name = @event.Name;
            CategoryId = @event.CategoryId;

            OrderAmount = 0;
            Review = new ReviewReadModel();
            FieldValues = new Dictionary<int, object>();
        }

        public void Apply(FieldValueChangedEvent @event)
        {
            FieldValues[@event.Id] = @event.Value;
        }

        public void Apply(OrderCompletedEvent @event)
        {
            OrderAmount += @event.Amount;
        }

        public void Apply(ReviewAddedEvent @event)
        {
            Review.Apply(@event);
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int OrderAmount { get; set; }

        public ReviewReadModel Review { get; set; }

        public Dictionary<int, object> FieldValues { get; set; }
    }

    public class ReviewReadModel
    {
        public ReviewReadModel()
        {
            Average = 0;
            Count = 0;
            Sum = 0;
        }

        public void Apply(ReviewAddedEvent @event)
        {
            Count++;
            Sum += @event.Rating;
            Average = Sum / Count;
        }

        public float Average { get; private set; }

        public int Count { get; private set; }

        public float Sum { get; private set; }
    }
}