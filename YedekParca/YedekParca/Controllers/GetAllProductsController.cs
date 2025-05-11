using Business.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Business.Services;

namespace YedekParca.WebAPI.Controllers
{
    
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize(Policy = "UserOnly")]
    public class GetAllProductsController : ControllerBase
    {


        private readonly GetAllProductsService? _getAllProducstService;

        public GetAllProductsController(GetAllProductsService? getAllProducstService)
        {
            _getAllProducstService = getAllProducstService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var urunler = await _getAllProducstService.GetAllProducts();
            if (urunler == null)
            {
                return NotFound("Ürün Yok");
            }
            return Ok(urunler);
        }
    }
}
