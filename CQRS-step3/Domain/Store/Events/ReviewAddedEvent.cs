using MediatR;

namespace CQRS_step3.Domain.Store.Events
{
    public class ReviewAddedEvent : INotification
    {
        public ReviewAddedEvent(int id, int productId, float rating)
        {
            Id = id;
            ProductId = productId;
            Rating = rating;
        }

        public int Id { get; }

        public int ProductId { get; }

        public float Rating { get; }
    }
}