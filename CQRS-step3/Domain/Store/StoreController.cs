using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CQRS_step3.Domain.ProductsManagememt.Models;
using MediatR;

namespace CQRS_step3.Domain.Store
{
    [RoutePrefix("orders")]
    public class StoreController : ApiController
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<Product>> Get([FromUri]GetProductsQuery query)
        {
            return await this._mediator.Send(query);
        }

        [HttpPut]
        [Route("{productId}/category")]
        public async Task ChangeCategory(int productId, ChangeProductCategoryCommand command)
        {
            command.ProductId = productId;

            await this._mediator.Send(command);
        }
    }
}
