using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediatR;

namespace CQRS_step3.Domain.Products
{
    public class CompleteOrderCommand : IRequest
    {
        public int ProductId { get; set; }

        public int Amount { get; set; }
    }
}