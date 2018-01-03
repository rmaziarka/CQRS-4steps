using CQRS_step3.Events;
using CQRS_step3.Models;
using MediatR;

namespace CQRS_step3.Domain.Products
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand>
    {
        private readonly ProductDatabase _database;
        private readonly IMediator _mediator;

        public AddProductCommandHandler(ProductDatabase database, IMediator mediator)
        {
            _database = database;
            _mediator = mediator;
        }

        public void Handle(AddProductCommand command)
        {
            // command validation
            // add product to database
            
            var @event = new ProductAddedEvent(product.Id, product.Name, product.CategoryId);
            _mediator.Publish(@event);
        }
    }
}