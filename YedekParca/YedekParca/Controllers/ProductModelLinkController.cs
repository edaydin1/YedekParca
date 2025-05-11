using Business.DTO;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YedekParca.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "AdminOnly")]
    public class ProductModelLinkController : ControllerBase
    {
        private readonly ProductModelLinkService _productModelLinkService;

        public ProductModelLinkController(ProductModelLinkService productModelLinkService)
        {
            _productModelLinkService = productModelLinkService;
        }

        [HttpPost]
        public async Task<IActionResult> AddLinkPM([FromBody] ProductModelLinkDTO productModelLink)
        {
            if (productModelLink == null)
            {
                return BadRequest("Model veya Product bilgileri geçersiz");
            }
            var addedLink = await _productModelLinkService.AddProductModelLink(productModelLink);
            return Ok(productModelLink);
        }
    }
}
