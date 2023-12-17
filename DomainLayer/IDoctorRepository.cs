using System.Collections.Generic;
using System;
using DomainLayer.Models;

namespace VezeetaDemo.RepositoryLayer
{
    public interface IDoctorRepository
    {
        public bool Login(string email, string password);
        public List<Patient> GetAllBooking(DateTime searchDate, int pageSize, int pageNumber);
        public bool ConfirmCheckup(int bookingId);

        //setting for adding dr's apponments

        public bool AddAppoinment(Appointment appointment);
        public bool UpdateAppoinment(int appointmentId, string newTime);
        public bool DeleteAppoinment(int appointmentId);


    }
}
