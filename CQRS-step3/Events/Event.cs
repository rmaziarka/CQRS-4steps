using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediatR;

namespace CQRS_step3.Events
{

    public class ProductAddedEvent : INotification
    {
        public ProductAddedEvent(int id, string name, int categoryId)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
        }

        public int Id { get; }

        public string Name { get; }

        public int CategoryId { get; }
    }

    public class ReviewAddedEvent : INotification
    {
        public ReviewAddedEvent(int id, int productId, float rating)
        {
            Id = id;
            ProductId = productId;
            Rating = rating;
        }

        public int Id { get; }

        public int ProductId { get; }

        public float Rating { get; }
    }

    public class OrderCompletedEvent : INotification
    {
        public OrderCompletedEvent(int id, int productId, int amount)
        {
            Id = id;
            ProductId = productId;
            Amount = amount;
        }

        public int Id { get; }

        public int ProductId { get; }

        public int Amount { get; }
    }

    public class FieldValueChangedEvent : INotification
    {
        public FieldValueChangedEvent(int id, int productId, object value)
        {
            Id = id;
            ProductId = productId;
            Value = value;
        }
        
        public int Id { get; }

        public int ProductId { get; }

        public object Value { get; }
    }
}