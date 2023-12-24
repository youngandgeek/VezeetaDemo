using DomainLayer;
using DomainLayer.Enums;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public PatientController(PatientService patientService, UserManager<ApplicationUser> userManager,
           RoleManager<IdentityRole> roleManager,
           IConfiguration configuration)
        {
            _patientService = patientService;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;

        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUpAsync([FromBody] PatientSignUpModel patientSignUpModel)

        {
            //check if user exist 

            var userExist = await _userManager.FindByEmailAsync(patientSignUpModel.Email);
            //if exists return ex
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                    new Response { Status = "Error", Message = "User Already Exists, please login instead" });
            }
            var result = await _patientService.SignUp(patientSignUpModel);

            if (result.Succeeded)
            {
                // Check if the "Patient" role exists before adding
                if (await _roleManager.RoleExistsAsync("Patient"))
                {
                    // Retrieve the user by email after signing up
                    var patient = await _userManager.FindByEmailAsync(patientSignUpModel.Email);

                    if (patient != null)
                    {
                        // Add the "Patient" role to the user
                        var addToRoleResult = await _userManager.AddToRoleAsync(patient, "Patient");

                        if (addToRoleResult.Succeeded)
                        {
                            return StatusCode(StatusCodes.Status201Created,
                                new Response { Status = "Success", Message = "Account Created Successfully" });
                        }
                        else
                        {
                            // Handle the case where adding the role was not successful
                            return StatusCode(StatusCodes.Status500InternalServerError,
                                new Response { Status = "Error", Message = "Failed to add role to user" });
                        }
                    }
                    else
                    {
                        // Handle the case where the user was not found after signing up
                        return StatusCode(StatusCodes.Status500InternalServerError,
                            new Response { Status = "Error", Message = "User not found after signing up" });
                    }
                }
                else
                {
                    // Handle the case where the "Patient" role doesn't exist
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Error", Message = "Role 'Patient' does not exist" });
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new Response { Status = "Error", Message = "Failed to sign up" });
            }

        }

        [HttpPost("login")]
            public IActionResult Login([FromBody] LoginRequestModel model)
            {
                var result = _patientService.Login(model.Email, model.Password);

                if (result)
                {
                    return Ok("Patient logged in successfully.");
                }

                return Unauthorized("Invalid credentials.");
            }

            [HttpGet("doctors")]
            public IActionResult GetDoctors([FromQuery] DoctorSearchRequestModel model)
            {
                var doctors = _patientService.GetDoctors(model.SearchDate, model.PageSize, model.PageNumber);

                return Ok(doctors);
            }
        }

    
      
       
    }



