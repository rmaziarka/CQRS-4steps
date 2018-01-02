using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CQRS_step3.Events;
using CQRS_step3.Models;
using MediatR;

namespace CQRS_step3.Domain.Products
{
    public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommand>
    {
        private readonly ProductDatabase _database;
        private readonly IMediator _mediator;

        public CompleteOrderCommandHandler(ProductDatabase database, IMediator mediator)
        {
            _database = database;
            _mediator = mediator;
        }

        public void Handle(CompleteOrderCommand command)
        {
            // command validation
            // create order in database

            var @event = new OrderCompletedEvent(order.Id, order.ProductId, order.Amount);
            _mediator.Publish(@event);
        }
    }
}