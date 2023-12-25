using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System.Threading.Tasks;

namespace VezeetaDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("login")]
        //Doctor Login
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestModel adminModel)
        {
            var result = await _adminService.Login(adminModel);

            if (result.Succeeded)
            {
                return Ok(new { Message = "Login successful" });
            }
            else
            {
                return Unauthorized(new { Message = "Invalid email or password" });
            }

        }
    }
}
