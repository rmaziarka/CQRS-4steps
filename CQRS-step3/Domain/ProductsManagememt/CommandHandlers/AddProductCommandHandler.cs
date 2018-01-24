using CQRS_step3.Database;
using CQRS_step3.Domain.ProductsManagememt.Commands;
using CQRS_step3.Domain.ProductsManagememt.Events;
using MediatR;

namespace CQRS_step3.Domain.ProductsManagememt.CommandHandlers
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly CqrsDatabase _database;
        private readonly IMediator _mediator;

        public AddProductCommandHandler(CqrsDatabase database, IMediator mediator)
        {
            _database = database;
            _mediator = mediator;
        }

        public int Handle(AddProductCommand command)
        {
            // command validation
            // add product to database

            var @event = new ProductAddedEvent(product.Id, product.Name, product.CategoryId);
            _mediator.Publish(@event);

            return product.Id;
        }
    }

}