using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("shopkart/admin")]
    public class AdminController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("dashboard")]
        public IActionResult GetDashboard()
        {
            return Ok(
                new
                {
                    message = "Welcome Admin",
                    user = User.Identity?.Name
                }
            );
        }
    }
}
