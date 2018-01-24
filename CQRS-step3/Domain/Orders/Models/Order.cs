using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_step3.Domain.Orders.Models
{
    public class Order
    {
        public int Id { get; }
        public int ProductId { get; }

        public int Amount { get; }
    }
}