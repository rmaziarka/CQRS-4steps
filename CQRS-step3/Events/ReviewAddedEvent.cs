using MediatR;

namespace CQRS_step3.Events
{
    public class ReviewAddedEvent : INotification
    {
        public ReviewAddedEvent(int id, int productId, int userId, int rating)
        {
            Id = id;
            ProductId = productId;
            UserId = userId;
            Rating = rating;
        }

        public int Id { get; private set; }

        public int ProductId { get; private set; }

        public int UserId { get; private set; }

        public int Rating { get; private set; }
    }
}