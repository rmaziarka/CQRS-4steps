using System.Collections.Generic;
using CQRS_step0.Controllers.Dto;
using CQRS_step0.Models;

namespace CQRS_step0.Services.Products
{
    public interface IProductsService
    {
        IEnumerable<Product> GetProducts(GetProductsDto dto);
        int ChangeProductFieldValue(ChangeProductFieldValueDto dto);
    }
}