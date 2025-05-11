using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YedekParca.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "UserOnly")]
    public class GetModelIDByYedekParca : ControllerBase
    {
        private readonly CompatibleModel _compatibleModel;

        public GetModelIDByYedekParca(CompatibleModel compatibleModel)
        {
            this._compatibleModel = compatibleModel;
        }

        [HttpGet("products/{productId}")]
        public async Task<IActionResult> GetModelByProductId(int productId)
        {
            var modeller = await _compatibleModel.GetModelIDByYedekParca(productId);

            if(modeller == null || !modeller.Any())
            {
                return NotFound("Uyumlu Model Bulunamadı");
            }

            return Ok(modeller);
        }
    }
}
