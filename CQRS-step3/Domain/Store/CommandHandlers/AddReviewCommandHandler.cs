using CQRS_step3.Database;
using CQRS_step3.Domain.Store.Commands;
using CQRS_step3.Domain.Store.Events;
using MediatR;

namespace CQRS_step3.Domain.Store.CommandHandlers
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, int>
    {
        private readonly CqrsDatabase _database;
        private readonly IMediator _mediator;

        public AddReviewCommandHandler(CqrsDatabase database, IMediator mediator)
        {
            _database = database;
            _mediator = mediator;
        }

        public int Handle(AddReviewCommand command)
        {
            // command validation
            // add review to database

            var @event = new ReviewAddedEvent(review.Id, review.UserId, review.ProductId, review.Rating);
            _mediator.Publish(@event);

            return review.Id;
        }
    }
}