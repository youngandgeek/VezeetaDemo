using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System.Threading.Tasks;

namespace VezeetaDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AdminService _adminService;
        private readonly PatientService _patientService;

        public AuthController(AdminService adminService, PatientService patientService)
        {
            _adminService = adminService;
            _patientService = patientService;
        }

        [HttpPost("admin-login")]
        public async Task<IActionResult> AdminLogin([FromBody] LoginRequestModel adminLogin)
        {
            var result = await _adminService.AdminLogin(adminLogin);

            if (result.Succeeded)
            {
                // Successful login
                return Ok(new { Message = "Admin login successful" });
            }

            // Failed login
            return Unauthorized(new { Message = "Admin login failed" });
        }

        [HttpPost("patient-login")]
        public async Task<IActionResult> PatientLogin([FromBody] LoginRequestModel patientLogin)
        {
            var result = await _patientService.PatientLogin(patientLogin);

            if (result.Succeeded)
            {
                // Successful login
                return Ok(new { Message = "Patient login successful" });
            }

            // Failed login
            return Unauthorized(new { Message = "Patient login failed" });
        }

        // ... other authentication-related endpoints ...
    }
}
  
