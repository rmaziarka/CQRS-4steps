using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_step0.Services.Products
{
    public class GetProductsDto
    {
        public int Page { get; set; }

        public int Take { get; set; }

        public int? CategoryId { get; set; }

        public Dictionary<int, object> FieldValues { get; set; }
    }
}