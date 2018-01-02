using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediatR;

namespace CQRS_step3.Domain.Products
{
    public class AddReviewCommand : IRequest
    {
        public int ProductId { get; set; }

        public float Rating { get; set; }
    }
}