using MediatR;

namespace CQRS_step3.Domain.Store.Commands
{
    public class AddReviewCommand : IRequest<int>
    {
        public int UserId { get; set; }

        public int ProductId { get; set; }

        public int Rating { get; set; }
    }
}