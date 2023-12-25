using DomainLayer;
using DomainLayer.Enums;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ServiceLayer;
using System;
using System.Data;
using System.Threading.Tasks;

namespace VezeetaDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {

        private readonly PatientService _patientService;

        public PatientController(PatientService patientService)
        {
            _patientService = patientService;


        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUpAsync([FromBody] PatientSignUpModel patientSignUpModel)

        {
            var result = await _patientService.SignUp(patientSignUpModel);

            if (result.Succeeded)
            {
                // Handle success
                return StatusCode(StatusCodes.Status201Created, new Response { Status = "Success", Message = "Account Created Successfully" });
            }
            else
            {
                // Handle failure, you can access error details using result.Errors
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Failed to sign up" });
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestModel model)
        {
            var result = await _patientService.Login(model);

            if (result.Succeeded)
            {
                // Handle successful login
                return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Login Successful" });
            }
            else
            {
                // Handle failed login
                return StatusCode(StatusCodes.Status401Unauthorized, new Response { Status = "Error", Message = "Invalid credentials" });
            }


            /**  "email": "emaness@gmail.com",

             * Patient@1233
             * **/
            /**
            [HttpGet("doctors")]
                public IActionResult GetDoctors([FromQuery] DoctorSearchRequestModel model)
                {
                    var doctors = _patientService.GetDoctors(model.SearchDate, model.PageSize, model.PageNumber);

                    return Ok(doctors);
                }
       
        

        **/
        }
    }
      
    }



