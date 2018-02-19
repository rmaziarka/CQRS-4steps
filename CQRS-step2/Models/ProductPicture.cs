using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_step2.Models
{
    public class ProductPicture
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int PictureId { get; set; }

        public Picture Picture { get; set; }

        public bool IsMain { get; set; }
    }
}