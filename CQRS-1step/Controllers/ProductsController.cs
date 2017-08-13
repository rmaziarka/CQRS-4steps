using System.Collections.Generic;
using System.Web.Http;
using CQRS_1step.Model;

namespace CQRS_1step.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/values
        public IEnumerable<Product> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
