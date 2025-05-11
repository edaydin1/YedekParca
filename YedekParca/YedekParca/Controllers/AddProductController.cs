using Business.DTO;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YedekParca.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "AdminOnly")]
    public class AddProductController : ControllerBase
    {
        private readonly AddProductService _productService;

        public AddProductController(AddProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductDTO addProductDTO)
        {
            if (addProductDTO == null)
            {
                return BadRequest("Ürün bilgileri geçersiz");
            }


            var addedProduct = await _productService.AddAsyncProduct(addProductDTO);
            return Ok(addedProduct);
        }
    }
}
