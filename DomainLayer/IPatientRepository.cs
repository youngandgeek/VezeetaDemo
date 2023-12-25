using DomainLayer;
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
         Task<IdentityResult> SignUp(PatientSignUpModel patientSignUpModel);

         Task<IdentityResult> Login(LoginRequestModel Patientlogin);

        //Doctor Data for patient

        //to get a list of all doctors available
        public List<Doctor> GetDoctors(int Page, int pageSize);
        //to see the doctor's appointment from the Appointment model
        public bool GetDoctorAppointments(Appointment appointment);

        //get patient booking
        public List<Booking> GetBooking();

        public bool CancelBooking(int bookingId);
        List<Doctor> GetDoctors(DateTime searchDate, int pageSize, int pageNumber);
    }
}