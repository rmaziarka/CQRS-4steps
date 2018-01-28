using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CQRS_step3.Domain.Store.Models;
using CQRS_step3.Events;
using MediatR;

namespace CQRS_step3.Domain.Store.EventHandlers
{
    public class ProductAddedEventHandler : INotificationHandler<ProductAddedEvent>
    {
        private readonly IProductReadModelRepository _repo;

        public ProductAddedEventHandler(IProductReadModelRepository repo)
        {
            _repo = repo;
        }

        public void Handle(ProductAddedEvent @event)
        {
            var product = new ProductReadModel(@event);
            _repo.Insert(product);
        }
    }
}