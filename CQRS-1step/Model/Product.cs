using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_1step.Model
{
    public class Product
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}