using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace YedekParca.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize(Policy = "UserOnly")]
    public class GetStockByProductId : ControllerBase
    {
        private readonly GetStockByProdIdService _service;

        public GetStockByProductId(GetStockByProdIdService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetStockProductId(int parcaId)
        {
            var stock =  await _service.GetStockProductId(parcaId);

            if(stock == null || !stock.Any())
            {
                return NotFound("Stok bilgisi bulunamadı.");
            }

            return Ok(stock);
        }
    }
}
