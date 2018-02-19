using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_step2.Models
{
    public class Manufacturer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Picture Picture { get; set; }

        public int PictureId { get; set; }
    }
}