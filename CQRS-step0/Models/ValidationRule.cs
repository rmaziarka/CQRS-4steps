using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_step0.Models
{
    public class ValidationRule { }

    public class IntegerRangeValidationRule : ValidationRule
    {
        public IntegerRangeValidationRule(int min, int max)
        {
            Min = min;
            Max = max;
        }
        public int Min { get; private set; }
        public int Max { get; private set; }
    }

    public class StringNotEmptyValidationRule : ValidationRule { }

    public class StringRegexValidationRule : ValidationRule
    {
        public StringRegexValidationRule(string regex)
        {
            Regex = regex;
        }

        public string Regex { get; private set; }
    }
}