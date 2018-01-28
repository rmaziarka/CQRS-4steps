using System.Collections.Generic;
using CQRS_step3.Events;

namespace CQRS_step3.Domain.Store.Models
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

        public int Id { get; private set; }

        public string Name { get; private set; }

        public int CategoryId { get; private set; }

        public int OrderAmount { get; private set; }

        public ReviewReadModel Review { get; private set; }

        public Dictionary<int, object> FieldValues { get; private set; }
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