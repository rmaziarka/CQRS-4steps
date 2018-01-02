using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CQRS_step3.Events;
using CQRS_step3.Models;
using MediatR;

namespace CQRS_step3.Domain.Products
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand>
    {
        private readonly ProductDatabase _database;
        private readonly IMediator _mediator;

        public AddReviewCommandHandler(ProductDatabase database, IMediator mediator)
        {
            _database = database;
            _mediator = mediator;
        }

        public void Handle(AddReviewCommand command)
        {
            // command validation
            // add review to database

            var @event = new ReviewAddedEvent(review.Id, review.ProductId, review.Rating);
            _mediator.Publish(@event);
        }
    }
}