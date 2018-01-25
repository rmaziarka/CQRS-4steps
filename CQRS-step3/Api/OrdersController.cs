using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CQRS_step3.Domain.Orders.Commands;
using CQRS_step3.Domain.ProductsManagememt.Models;
using MediatR;

namespace CQRS_step3.Api
{
    [RoutePrefix("orders")]
    public class OrdersController : ApiController
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        [Route("")]
        public async Task<int> CompleteOrder([FromUri]CompleteOrderCommand command)
        {
            return await this._mediator.Send(command);
        }
    }
}
