using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using CQRS_1step.Domain.Products;
using CQRS_1step.Models;
using MediatR;

namespace CQRS_1step.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Product>> Get([FromUri]GetProductsQuery query)
        {
            return await this.mediator.Send(query);
        }

        [HttpPut]
        [Route("{productId}/category")]
        public async Task ChangeCategory(int productId, ChangeProductCategoryCommand command)
        {
            command.ProductId = productId;

            await this.mediator.Send(command);
        }
    }
}
