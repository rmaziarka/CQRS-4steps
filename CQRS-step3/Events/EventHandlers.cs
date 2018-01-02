using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CQRS_step3.Models;
using Dapper;
using MediatR;

namespace CQRS_step3.Events
{
    public class ProductAddedEventHandler: INotificationHandler<ProductAddedEvent>
    {
        private readonly IProductReadModelRepository _repo;

        public ProductAddedEventHandler(IProductReadModelRepository repo)
        {
            _repo = repo;
        }

        public void Handle(ProductAddedEvent @event)
        {
            var product = new ProductReadModel(@event);
            _repo.Save(product);
        }
    }

    public class ReviewAddedEventHandler : INotificationHandler<ReviewAddedEvent>
    {
        private readonly IProductReadModelRepository _repo;

        public ReviewAddedEventHandler(IProductReadModelRepository repo)
        {
            _repo = repo;
        }

        public void Handle(ReviewAddedEvent @event)
        {
            var product = _repo.Find(@event.ProductId);
            product.Apply(@event);
            _repo.Save(product);
        }
    }

    public class OrderCompletedEventHandler : INotificationHandler<OrderCompletedEvent>
    {
        private readonly IProductReadModelRepository _repo;

        public OrderCompletedEventHandler(IProductReadModelRepository repo)
        {
            _repo = repo;
        }

        public void Handle(OrderCompletedEvent @event)
        {
            var product = _repo.Find(@event.ProductId);
            product.Apply(@event);
            _repo.Save(product);
        }
    }

    public class FieldValueChangedEventHandler : INotificationHandler<FieldValueChangedEvent>
    {
        private readonly IProductReadModelRepository _repo;

        public FieldValueChangedEventHandler(IProductReadModelRepository repo)
        {
            _repo = repo;
        }

        public void Handle(FieldValueChangedEvent @event)
        {
            var product = _repo.Find(@event.ProductId);
            product.Apply(@event);
            _repo.Save(product);
        }
    }

    public class ProductReadModelRepository : IProductReadModelRepository
    {
        private readonly SqlConnection _sqlConnection;

        public ProductReadModelRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public ProductReadModel Find(int productId)
        {
            return _sqlConnection.QuerySingle<ProductReadModel>("SELECT * FROM Products WHERE Id = @Id", new { Id = productId });
        }

        public void Save(ProductReadModel product)
        {
            _sqlConnection.Execute(
                @"INSERT INTO Products (Id, Name, CategoryId, OrderAmount, Review, FieldValues) 
                VALUES(@Id, @Name, @CategoryId, @OrderAmount @Review, @FieldValues)",
                product);
        }
    }

    public interface IProductReadModelRepository
    {
        ProductReadModel Find(int productId);
        void Save(ProductReadModel model);
    }
}