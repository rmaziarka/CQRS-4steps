using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CQRS_step3.Events;
using CQRS_step3.Models;
using MediatR;

namespace CQRS_step3.Domain.Products
{
    public class ChangeFieldValueCommandHandler
    {
        private readonly ProductDatabase _database;
        private readonly IMediator _mediator;

        public ChangeFieldValueCommandHandler(ProductDatabase database, IMediator mediator)
        {
            _database = database;
            _mediator = mediator;
        }

        public void Handle(ChangeFieldValueCommand command)
        {
            // command validation
            // change field value for product

            var @event = new FieldValueChangedEvent(fieldValue.Id, fieldValue.Value);
            _mediator.Publish(@event);
        }
    }
}