using DomainLayer;
using DomainLayer.Enums;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class PatientRepository :IPatientRepository
    {

        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientRepository(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public  async Task<IdentityResult> SignUp(UserSignUpModel patientSignUpModel)
        {
            try
            {
                // Check if passwords match
                if (patientSignUpModel.Password != patientSignUpModel.ConfirmPassword)
                {
                    // Handle the case where passwords don't match
                    return IdentityResult.Failed(new IdentityError { Description = "Passwords do not match" });
                }

                // Check if user exists
                var userExist = await _userManager.FindByEmailAsync(patientSignUpModel.Email);
                // If exists, return error
                if (userExist != null)
                {
                    return IdentityResult.Failed(new IdentityError { Code = "403", Description = "Failed to sign up" });
                }

                // Create patient
                var patient = new ApplicationUser
                {
                //    UserName = patientSignUpModel.Username,
                  FirstName= patientSignUpModel.FirstName,
                  LastName= patientSignUpModel.LastName,
                    Email = patientSignUpModel.Email,
                    Gender = (Gender)patientSignUpModel.Gender,
                    DateOfBirth = (DateTime)patientSignUpModel.DateOfBirth,
                    Phone=patientSignUpModel.Phone
                   
                };
                var result = await _userManager.CreateAsync(patient, patientSignUpModel.Password);

                return result;
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (log, throw, etc.)
                return IdentityResult.Failed(new IdentityError { Description = "Failed to sign up." });
            }
        }

        public async Task<SignInResult> PatientLogin(LoginRequestModel Patientlogin) { 
        // The Login method is implemented in the PatientService.
        throw new NotImplementedException("Login method is not implemented in PatientRepository.");
    }
        /**
    public List<Doctor> GetDoctors(DateTime searchDate, int pageSize, int pageNumber)
        {
            // Implement logic to get a list of doctors based on search criteria
            var doctors = _context.Doctors
                .Include(d => d.Appointments) // Include appointments if needed
                .Where(d => d.IsActive)       // Add any filtering conditions
                .ToList();

            return doctors;
        }

        List<Doctor> IPatientRepository.GetDoctors(int Page, int pageSize)
        {
            throw new NotImplementedException();
        }

        bool IPatientRepository.GetDoctorAppointments(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        List<Booking> IPatientRepository.GetBooking()
        {
            throw new NotImplementedException();
        }

        bool IPatientRepository.CancelBooking(int bookingId)
        {
            throw new NotImplementedException();
        }
    **/
        }
}
