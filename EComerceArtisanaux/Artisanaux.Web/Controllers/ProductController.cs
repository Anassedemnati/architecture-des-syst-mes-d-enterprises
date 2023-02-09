using Artisanaux.Web.Models;
using Artisanaux.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Artisanaux.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProdactService _pruoductService;

        public ProductController(IProdactService pruoductService)
        {
            _pruoductService = pruoductService;
        }

        public async  Task<IActionResult> ProductIndex()
        {
            List<ProductDto> list = new List<ProductDto>();
            var response = await _pruoductService.GetAllProductsAsync<ResponseDto>();
            if (response != null)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
        //crud operation create delete update
        [HttpGet]
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto productDto)
        {
            var response = await _pruoductService.CreateProductAsync<ResponseDto>(productDto);
            if (response != null)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ProductEdit(int id)
        {
            ProductDto productDto = new ProductDto();
            var response = await _pruoductService.GetProductsAsync<ResponseDto>(id, "");
            if (response != null && response.IsSuccess)
            {
                productDto = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
            }
            return View(productDto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductDto productDto)
        {
            var response = await _pruoductService.UpdateProductAsync<ResponseDto>(productDto.ProductId, productDto);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
            return View();              
        }
        [HttpGet]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var response = await _pruoductService.DeleteProductAsync<ResponseDto>(id, "");
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
            return View();
        }

    }
}
