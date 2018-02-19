using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_step2.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}