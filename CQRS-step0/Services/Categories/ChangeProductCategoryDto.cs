using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_step0.Services.Categories
{
    public class ChangeProductCategoryDto
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }
    }
}