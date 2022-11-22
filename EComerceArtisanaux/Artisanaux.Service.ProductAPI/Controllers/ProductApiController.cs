using Artisanaux.Service.ProductAPI.Models.Dto;
using Artisanaux.Service.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Artisanaux.Service.ProductAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        [HttpGet]
        public async Task<object> Get() {
            IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
            return Ok(productDtos);
        }
            
    }
}
