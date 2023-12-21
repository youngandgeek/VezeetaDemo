using DomainLayer;
using DomainLayer.Enums;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System;

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
            public IActionResult SignUp([FromBody] PatientSignUpRequestModel model)
            {
                var result = _patientService.SignUp(model.Image, model.FirstName, model.LastName, model.Email, model.Phone, model.Gender, model.DateOfBirth);

                if (result)
                {
                    return Ok("Patient signed up successfully.");
                }

                return BadRequest("Failed to sign up patient.");
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



