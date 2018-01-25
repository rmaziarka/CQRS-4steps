using System.Linq;
using CQRS_step3.Database;
using CQRS_step3.Domain.ProductsManagememt.Commands;
using CQRS_step3.Domain.ProductsManagememt.Events;
using MediatR;

namespace CQRS_step3.Domain.ProductsManagememt.CommandHandlers
{
    public class ChangeFieldValueCommandHandler: IRequestHandler<ChangeFieldValueCommand>
    {
        private readonly CqrsDatabase _database;
        private readonly IMediator _mediator;

        public ChangeFieldValueCommandHandler(CqrsDatabase database, IMediator mediator)
        {
            _database = database;
            _mediator = mediator;
        }

        public void Handle(ChangeFieldValueCommand command)
        {
            // command validation
            var fieldValue = _database.FieldValues.Single(fv => fv.Id == command.FieldValueId);
            fieldValue.ChangeValue(command.Value);

            var @event = new FieldValueChangedEvent(fieldValue.Id, fieldValue.ProductId, fieldValue.Value);
            _mediator.Publish(@event);
        }
    }
}