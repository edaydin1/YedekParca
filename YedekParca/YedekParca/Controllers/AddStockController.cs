using Business.DTO;
using Business.Services;
using Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YedekParca.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize(Policy = "AdminOnly")]
    public class AddStockController : ControllerBase
    {
        private readonly AddStockService _service;

        public AddStockController(AddStockService stockService)
        {
            _service = stockService;
        }

        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] AddStockDTO addStockDTO)
        {
            if (addStockDTO == null)
            {
                return BadRequest("Stok bilgileri geçersiz");
            }
            var addedModel = await _service.AddAsyncStock(addStockDTO);
            return Ok(addedModel);
        }
    }
}
