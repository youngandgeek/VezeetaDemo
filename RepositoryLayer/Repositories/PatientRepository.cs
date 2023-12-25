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
    public class PatientRepository : IPatientRepository
    {

        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientRepository(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public  async Task<IdentityResult> SignUp(PatientSignUpModel patientSignUpModel)
        {
            try
            {
                var patient = new Patient
                {
                    UserName = patientSignUpModel.Username,
                    Email = patientSignUpModel.Email,
                    PhoneNumber = patientSignUpModel.Phone,
                    Gender = (Gender)patientSignUpModel.Gender,
                    DateOfBirth = (DateTime)patientSignUpModel.DateOfBirth
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


        public async Task<IdentityResult> Login(LoginRequestModel Patientlogin)
        {
            // Implement login logic based on your requirements
            // For example, check credentials against the database
            var patient = _context.Patients.FirstOrDefault(p => p.PatientUser.Email == Patientlogin.Email);

            if (patient != null)
            {
                // Validate password here
                // Example: if (PasswordHashing.ValidatePassword(password, patient.PatientUser.PasswordHash))
                // {
                //     return true;
                // }
            }

                  return IdentityResult.Failed(new IdentityError { Description = "Failed to Login." });
      
        }

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
    }
}
