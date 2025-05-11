using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Services;
using Business.WebAPI;
using Business.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Business.Services
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize(Policy = "AdminOnly")]
    public class AddModelController : ControllerBase
    {
        private readonly AddModelService _modelService;

        public AddModelController(AddModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpPost]
        public async Task<IActionResult> AddModel([FromBody] ModelDefDTO addModelDTO)
        {
            if (addModelDTO == null)
            {
                return BadRequest("Model bilgileri geçersiz");
            }
            var addedModel = await _modelService.AddAsyncModel(addModelDTO);
            return Ok(addedModel);
        }
    }
}
