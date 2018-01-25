using CQRS_step3.Database;
using CQRS_step3.Domain.Store.Commands;
using CQRS_step3.Domain.Store.Events;
using CQRS_step3.Domain.Store.Models;
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
            var review = new Review(command.ProductId, command.UserId, command.Rating);
            _database.Reviews.Add(review);
            _database.SaveChanges();


            var @event = new ReviewAddedEvent(review.Id, review.UserId, review.ProductId, review.Rating);
            _mediator.Publish(@event);

            return review.Id;
        }
    }
}