using DomainLayer.Enums;
using DomainLayer.Models;
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

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

   
        public bool SignUp(string image, string firstName, string lastName, string email, string phone, Gender gender, DateTime dateOfBirth)
        {
            try
            {
                var patient = new Patient
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phone,
                    Gender = gender,
                    DateOfBirth = dateOfBirth,
                   

                };

                _context.Patients.Add(patient);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (log, throw, etc.)
                return false;
            }
        }

        public bool Login(string email, string password)
        {
            // Implement login logic based on your requirements
            // For example, check credentials against the database
            var patient = _context.Patients.FirstOrDefault(p => p.PatientUser.Email == email);

            if (patient != null)
            {
                // Validate password here
                // Example: if (PasswordHashing.ValidatePassword(password, patient.PatientUser.PasswordHash))
                // {
                //     return true;
                // }
            }

            return false;
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
