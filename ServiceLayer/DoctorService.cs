using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using VezeetaDemo.RepositoryLayer;

namespace ServiceLayer
{
    public class DoctorService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly DoctorRepository _doctorRepository;

        public DoctorService(DoctorRepository doctorRepository,
         UserManager<ApplicationUser> userManager,
         RoleManager<IdentityRole> roleManager,
         IConfiguration configuration,
         SignInManager<ApplicationUser> signInManager
         )
        {
            _doctorRepository = doctorRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }
      //  [Authorize(Roles = "Doctor")]
        public async Task<SignInResult> Login(LoginRequestModel doctorLogin)
        {
            // Find the user by email
            var user = await _userManager.FindByEmailAsync(doctorLogin.Email);

            // Check if the user exists and validate the password
            if (user != null && await _userManager.CheckPasswordAsync(user, doctorLogin.Password))
            {
                // Check if the user has the "Doctor" role
                if (await _userManager.IsInRoleAsync(user, "Doctor"))
                {
                    // User is authenticated successfully and has the "Doctor" role
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return SignInResult.Success;
                }
            }
                // Authentication failed or user doesn't have the "Doctor" role
                return SignInResult.Failed;
            

        }
            public List<Patient> GetAllBooking(DateTime searchDate, int pageSize, int pageNumber)
        {
            // Additional validation and business logic can be added here if needed

            return _doctorRepository.GetAllBooking(searchDate, pageSize, pageNumber);
        }

        public bool ConfirmCheckup(int bookingId)
        {
            // Additional validation and business logic can be added here if needed

            return _doctorRepository.ConfirmCheckup(bookingId);
        }

        public bool AddAppointment(Appointment appointment)
        {
            // Additional validation and business logic can be added here if needed

            return _doctorRepository.AddAppoinment(appointment);
        }

        public bool UpdateAppointment(int appointmentId, string newTime)
        {
            // Additional validation and business logic can be added here if needed

            return _doctorRepository.UpdateAppoinment(appointmentId, newTime);
        }

        public bool DeleteAppointment(int appointmentId)
        {
            // Additional validation and business logic can be added here if needed

            return _doctorRepository.DeleteAppoinment(appointmentId);
        }

    }
}
