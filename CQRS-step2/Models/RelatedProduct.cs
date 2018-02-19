using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_step2.Models
{
    public class RelatedProduct
    {
        public int Id { get; set; }

        public int MainProductId { get; set; }

        public Product MainProduct { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}