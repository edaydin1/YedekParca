using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YedekParca.WebAPI;

namespace YedekParca.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "UserOnly")]
    public class AvailableProductWithModelID : ControllerBase
    {
        private readonly AvailableProducts _yedekParcaService;

        public AvailableProductWithModelID(AvailableProducts yedekParcaService)
        {
            _yedekParcaService = yedekParcaService;
        }

        // ModelID'ye göre uyumlu yedek parçaları listele
        [HttpGet("model/{modelId}")]
        public async Task<IActionResult> GetYedekParcalarByModelId(int modelId)
        {
            var yedekParcalar = await _yedekParcaService.GetYedekParcalarByModelId(modelId);
            
            if (yedekParcalar == null || !yedekParcalar.Any())
            {
                return NotFound("Uyumlu yedek parça bulunamadı.");
            }

            return Ok(yedekParcalar);
        }
    }
}
