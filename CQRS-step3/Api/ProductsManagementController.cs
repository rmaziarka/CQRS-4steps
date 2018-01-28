using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CQRS_step3.Domain.ProductsManagememt.Commands;
using CQRS_step3.Domain.ProductsManagememt.Models;
using MediatR;

namespace CQRS_step3.Api
{
    [RoutePrefix("productManagement")]
    public class ProductsManagementController : ApiController
    {
        private readonly IMediator _mediator;

        public ProductsManagementController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [Route("products")]
        public async Task<int> AddProduct(AddProductCommand command)
        {
            return await this._mediator.Send(command);
        }

        [HttpPut]
        [Route("fieldValues/{fieldValueId}")]
        public async Task ChangeFieldValue(int fieldValueId, ChangeFieldValueCommand command)
        {
            command.FieldValueId = fieldValueId;

            await this._mediator.Send(command);
        }
    }
}
