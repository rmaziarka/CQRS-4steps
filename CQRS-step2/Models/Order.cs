using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_step2.Models
{
    public class Order
    {
        public int Id { get; set; }

        public virtual IEnumerable<OrderItem> OrderItems { get; set; }


    }
}