using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VezeetaDemo.RepositoryLayer;

namespace ServiceLayer
{
    public class DoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public bool Login(string email, string password)
        {
            // Additional validation and business logic can be added here if needed

            return _doctorRepository.Login(email, password);
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
