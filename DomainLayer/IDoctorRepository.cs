using System.Collections.Generic;
using System;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace VezeetaDemo.RepositoryLayer
{
    public interface IDoctorRepository
    {
        Task<SignInResult> Login(LoginRequestModel drLoginModel);

        /**
      //  public List<Patient> GetAllBooking(DateTime searchDate, int pageSize, int pageNumber);
        public bool ConfirmCheckup(int bookingId);

        //setting for adding dr's apponments

        public bool AddAppoinment(Appointment appointment);
        public bool UpdateAppoinment(int appointmentId, string newTime);
        public bool DeleteAppoinment(int appointmentId);
**/

    }
}
