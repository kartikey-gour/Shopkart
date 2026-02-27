using Backend.DTOs;
using Backend.Services.Implementations;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("shopkart/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        //ctor based DI
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<AuthResponseDto>> Register(RegisterRequestDto dto)
        {
            var result = await _userService.RegisterAsync(dto);

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponseDto>> Login(LoginRequestDto dto)
        {
            var result = await _userService.LoginAsync(dto);

            return Ok(result);
        }
    }
}
