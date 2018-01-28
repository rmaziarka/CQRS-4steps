using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CQRS_step3.Domain.ProductsManagememt.Models;
using CQRS_step3.Domain.ProductsManagememt.Commands;
using CQRS_step3.Domain.Store.Commands;
using CQRS_step3.Domain.Store.Models;
using CQRS_step3.Domain.Store.Queries;
using MediatR;

namespace CQRS_step3.Api
{
    [RoutePrefix("store")]
    public class StoreController : ApiController
    {
        private readonly IMediator _mediator;

        public StoreController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        [Route("reviews")]
        public async Task<int> AddReview(AddReviewCommand command)
        {
            return await this._mediator.Send(command);
        }

        [HttpGet]
        [Route("products")]
        public async Task<IEnumerable<ProductReadModel>> GetProducts(GetProductsQuery query)
        {
            return await this._mediator.Send(query);
        }
    }
}
