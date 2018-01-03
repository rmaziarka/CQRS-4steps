using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MediatR;

namespace CQRS_step3.Domain.Products
{
    public class ChangeFieldValueCommand:IRequest
    {
        public int FieldValueId { get; set; }

        public object Value { get; set; }
    }
}