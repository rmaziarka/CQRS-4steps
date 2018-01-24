using MediatR;

namespace CQRS_step3.Domain.ProductsManagememt.Events
{
    public class FieldValueChangedEvent : INotification
    {
        public FieldValueChangedEvent(int id, int productId, object value)
        {
            Id = id;
            ProductId = productId;
            Value = value;
        }

        public int Id { get; }

        public int ProductId { get; }

        public object Value { get; }
    }
}