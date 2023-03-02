using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PointengBE.Models;
using PointengBE.Services.Interfaaces;

namespace PointengBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataWithErros _action = new();
        private readonly AuthInterface? _Iclaim;
        public AuthController(AuthInterface? Iclaim)
        {
            _Iclaim = Iclaim;
        }
        [HttpGet("Getclims")]
        public async Task<IActionResult> getUserClaims()
        {
            var claims = await _Iclaim.GetName(User);
            return Ok(claims.Result);
        }
    }
}
