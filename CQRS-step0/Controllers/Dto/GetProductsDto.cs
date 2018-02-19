using System.Collections.Generic;

namespace CQRS_step0.Controllers.Dto
{
    public class GetProductsDto
    {
        public int Page { get; set; }

        public int Take { get; set; }

        public int? CategoryId { get; set; }

        public Dictionary<int, object> FieldValues { get; set; }
    }
}