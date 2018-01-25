using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_step3.Domain.Store.Models
{
    public class Review
    {
        public Review(int productId, int userId, int rating)
        {
            ProductId = productId;
            UserId = userId;
            Rating = rating;
        }

        public int Id { get; private set; }

        public int ProductId { get; private set; }

        public int UserId { get; private set; }

        public int Rating { get; private set; }
    }
}