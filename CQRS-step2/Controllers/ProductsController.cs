using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CQRS_step2.Domain.Products.Commands;
using CQRS_step2.Domain.Products.Query;
using CQRS_step2.Models;
using MediatR;

namespace CQRS_step2.Controllers
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
        [Route("dapper")]
        public async Task<IEnumerable<Product>> Get([FromUri]GetProductsByAutoMapperQuery query)
        {
            return await this.mediator.Send(query);
        }

        [HttpGet]
        [Route("automapper")]
        public async Task<IEnumerable<Product>> Get([FromUri]GetProductsByDapperQuery query)
        {
            return await this.mediator.Send(query);
        }

        [HttpPut]
        [Route("{productId}/category")]
        public async Task ChangeCategory(int productId, ChangeProductFieldValueCommand command)
        {
            command.ProductId = productId;

            await this.mediator.Send(command);
        }
    }
}
