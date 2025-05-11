using Business.DTO;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YedekParca.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "AdminOnly")]
    public class SatisController : ControllerBase
    {
        private readonly SatisService _stokService;
        public SatisController(SatisService stokService)
        {
            _stokService = stokService;
        }

        [HttpPut]
        public async Task<IActionResult> SatisYap([FromBody] StokSatisDTO dto)
        {
            try
            {
                int kalanStok = await _stokService.SatisYapAsync(dto);
                return Ok(new
                {
                    Message = $"{dto.Miktar} adet ürün satıldı ({dto.Sehir.ToUpper()}).",
                    KalanStok = kalanStok
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
