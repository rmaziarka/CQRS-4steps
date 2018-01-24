using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CQRS_step0.Models;
using CQRS_step0.Services;
using CQRS_step0.Services.Products;

namespace CQRS_step0.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }


        [HttpGet]
        [Route("")]
        public IEnumerable<Product> Get([FromUri]GetProductsDto dto)
        {
            return _productsService.GetProducts(dto);
        }

        [HttpPut]
        [Route("{productId}/category")]
        public void ChangeCategory(int productId)
        {
        }
    }
}
