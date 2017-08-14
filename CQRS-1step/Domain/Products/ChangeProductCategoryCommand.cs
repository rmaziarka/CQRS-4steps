using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediatR;

namespace CQRS_1step.Domain.Products
{
    public class ChangeProductCategoryCommand:IRequest
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }
    }
}