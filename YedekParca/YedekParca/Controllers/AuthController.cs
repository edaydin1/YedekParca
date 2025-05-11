// Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Business.Services;
using Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Data.Mapping;

namespace YedekParca.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IValidator<LoginRequestDTO> _validator;

        public AuthController(
            AuthService authService,
            IValidator<LoginRequestDTO> validator)
        {
            _authService = authService;
            _validator = validator;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDTO request)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    ErrorMessage = e.ErrorMessage
                }).ToList();

                return BadRequest(new
                {
                    Message = "Lütfen girdiğiniz bilgileri kontrol edin.",
                    Errors = errors
                });
            }
                

            Users user;
            if (request.Username == "admin" && request.Password == "123")
            {
                user = new Users { UserName = "admin", Role = "admin" };
            }
            else if (request.Username == "user" && request.Password == "user")
            {
                user = new Users { UserName = "user", Role = "user" };
            }
            else
            {
                return Unauthorized("Geçersiz kimlik bilgileri");
            }

            var token = _authService.GenerateJwtToken(user);
            return Ok(new { Token = token });
        }
    }
}