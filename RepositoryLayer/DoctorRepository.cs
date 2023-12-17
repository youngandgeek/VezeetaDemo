using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VezeetaDemo.RepositoryLayer;

namespace RepositoryLayer
{
    internal class DoctorRepository : IDoctorRepository
    {
        public bool Login(string email, string password)
        {
            throw new NotImplementedException();
        }



        public List<Patient> GetAllBooking(DateTime searchDate, int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }


     
        public bool AddAppoinment(Appointment appointment)
        {
            throw new NotImplementedException();
        }


     
        public bool UpdateAppoinment(int appointmentId, string newTime)
        {
            throw new NotImplementedException();
        }


        public bool DeleteAppoinment(int appointmentId)
        {
            throw new NotImplementedException();
        }


        public bool ConfirmCheckup(int bookingId)
        {
            throw new NotImplementedException();
        }

    }
}
