using Business.DTO;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YedekParca.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "AdminOnly")]
    public class StokEkleController : ControllerBase
    {
        private readonly StokEkleService _stokService;
        public StokEkleController(StokEkleService stokEkleService)
        {
            _stokService = stokEkleService;
        }

        [HttpPut]
        public async Task<IActionResult> SatisYap([FromBody] StokSatisDTO dto)
        {
            try
            {
                int YeniStok = await _stokService.SatisYapAsync(dto);
                return Ok(new
                {
                    Message = $"{dto.Miktar} adet ürün eklendi ({dto.Sehir.ToUpper()}).",
                    YeniStok = YeniStok
                });
            }
            catch (ArgumentException argEx)
            {
                return BadRequest(argEx.Message);
            }
            catch (InvalidOperationException invOpEx)
            {
                return BadRequest(invOpEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Sunucu hatası: " + ex.Message);
            }
        }

    }
}
