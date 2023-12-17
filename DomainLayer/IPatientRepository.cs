using DomainLayer.Enums;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IPatientRepository
    {
        public bool SignUp(string image, string FirstName, string LastName,
            string email, string phone, Gender gender, DateTime dateOfBirth);
        // Task<IdentityResult> RegisterPatientAsync(SignupViewModel model);

        public bool Login(string email, string password);

        //Doctor Data for patient

        //to get a list of all doctors available
        public List<Doctor> GetDoctors(int Page, int pageSize);
        //to see the doctor's appointment from the Appointment model
        public bool GetDoctorAppointments(Appointment appointment);

        //get patient booking
        public List<Booking> GetBooking();

        public bool CancelBooking(int bookingId);
    }
}