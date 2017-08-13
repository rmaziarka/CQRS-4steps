using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using CQRS_1step.Domain.Products;
using CQRS_1step.Models;
using MediatR;

namespace CQRS_1step.Controllers
{
    public class ProductsController : ApiController
    {
        private IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IEnumerable<Product>> Get([FromUri]GetProductsQuery query)
        {
            return await this.mediator.Send(query);
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
