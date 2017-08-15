using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_step0.Services.Products
{
    public class GetProductsDto
    {
        public int Page { get; set; }

        public int Take { get; set; }
    }
}