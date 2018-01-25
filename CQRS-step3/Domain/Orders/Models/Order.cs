using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_step3.Domain.Orders.Models
{
    public class Order
    {
        public Order(int productId, int amount)
        {
            ProductId = productId;
            Amount = amount;
        }

        public int Id { get; private set; }

        public int ProductId { get; private set; }

        public int Amount { get; private set; }
    }
}