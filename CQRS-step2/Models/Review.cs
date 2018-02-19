using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_step2.Models
{
    public class Review
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public float Rating { get; set; }

        public DateTime CreateDate { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}