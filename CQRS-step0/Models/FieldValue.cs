using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_step0.Models
{
    public class FieldValue
    {
        public int Id { get; set; }

        public int FieldId { get; set; }

        public Field Field { get; set; }
    }

    public class IntegerFieldValue : FieldValue
    {
        public int IntegerValue { get; set; }
    }

    public class StringFieldValue : FieldValue
    {
        public string StringValue { get; set; }
    }

    // etc.
}