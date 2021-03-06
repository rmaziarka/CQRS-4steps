﻿using CQRS_step3.Database;
using CQRS_step3.Domain.Orders.Commands;
using CQRS_step3.Domain.Orders.Models;
using CQRS_step3.Events;
using MediatR;

namespace CQRS_step3.Domain.Orders.CommandHandlers
{
    public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommand, int>
    {
        private readonly CqrsDatabase _database;
        private readonly IMediator _mediator;

        public CompleteOrderCommandHandler(CqrsDatabase database, IMediator mediator)
        {
            _database = database;
            _mediator = mediator;
        }

        public int Handle(CompleteOrderCommand command)
        {
            // command validation ommited
            var order = new Order(command.ProductId, command.Amount);
            _database.Orders.Add(order);
            _database.SaveChanges();

            var @event = new OrderCompletedEvent(order.Id, order.ProductId, order.Amount);
            _mediator.Publish(@event);

            return order.Id;
        }
    }
}