using MediatR;

namespace CQRS_step3.Events
{
    public class OrderCompletedEvent : INotification
    {
        public OrderCompletedEvent(int id, int productId, int amount)
        {
            Id = id;
            ProductId = productId;
            Amount = amount;
        }

        public int Id { get; }

        public int ProductId { get; }

        public int Amount { get; }
    }
}