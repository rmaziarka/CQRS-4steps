using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CQRS_step3.Domain.Products;
using CQRS_step3.Models;
using MediatR;

namespace CQRS_step3.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private readonly IMediator mediator;

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
