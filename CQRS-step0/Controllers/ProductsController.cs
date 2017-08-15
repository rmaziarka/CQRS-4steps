using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CQRS_step0.Models;
using CQRS_step0.Services;
using CQRS_step0.Services.Categories;
using CQRS_step0.Services.Products;

namespace CQRS_step0.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private IProductsService _productsService;
        private ICategoriesService _categoriesService;

        public ProductsController(IProductsService productsService, 
            ICategoriesService categoriesService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
        }


        [HttpGet]
        [Route("")]
        public IEnumerable<Product> Get([FromUri]GetProductsDto dto)
        {
            return _productsService.GetProducts(dto);
        }

        [HttpPut]
        [Route("{productId}/category")]
        public void ChangeCategory(int productId, ChangeProductCategoryDto dto)
        {
            dto.ProductId = productId;

            _categoriesService.ChangeProductCategory(dto);

        }
    }
}
