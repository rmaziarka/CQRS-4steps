using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_step3.Domain.Store.Models
{
    public class Review
    {
        public int Id { get; }

        public int ProductId { get; }

        public int UserId { get; }

        public int Rating { get; }
    }
}