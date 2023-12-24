using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System;

namespace VezeetaDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class DoctorController : ControllerBase
        {
            private readonly DoctorService _doctorService;

            public DoctorController(DoctorService doctorService)
            {
                _doctorService = doctorService;
            }

            [HttpPost("login")]
            public IActionResult Login([FromBody] LoginRequestModel model)
            {
                var result = _doctorService.Login(model.Email, model.Password);

                if (result)
                {
                    return Ok("Doctor logged in successfully.");
                }

                return Unauthorized("Invalid credentials.");
            }
        //if u want to authorize only doctor to see the bookings when logged in.
       // [Authorize(Roles="Doctor")] and if you're using mvc-> in .cshtml page @if(User.IsInRole("Doctor") <h>hey</h>
       
            [HttpGet("bookings")]
            public IActionResult GetAllBookings([FromQuery] BookingSearchRequestModel model)
            {
                var patients = _doctorService.GetAllBooking(model.SearchDate, model.PageSize, model.PageNumber);

                return Ok(patients);
            }
/**
            [HttpPost("confirm-checkup")]
            public IActionResult ConfirmCheckup([FromBody] ConfirmCheckupRequestModel model)
            {
                var result = _doctorService.ConfirmCheckup(model.BookingId);

                if (result)
                {
                    return Ok("Checkup confirmed successfully.");
                }

                return BadRequest("Failed to confirm checkup.");
            }

   **/
        /**     [HttpPost("add-appointment")]
            public IActionResult AddAppointment([FromBody] AppointmentRequestModel model)
            {
                var appointment = new Appointment // Create the Appointment object based on your model
                {
                    // Map properties from the model
                };

                var result = _doctorService.AddAppointment(appointment);

                if (result)
                {
                    return Ok("Appointment added successfully.");
                }

                return BadRequest("Failed to add appointment.");
            }

            // Implement other actions for updating and deleting appointments as needed
        }

      **/

 /**   
        public class ConfirmCheckupRequestModel
        {
            public int BookingId { get; set; }
        }

        public class AppointmentRequestModel
        {
            // Properties for creating an appointment
    
    }
    **/
    }

}


