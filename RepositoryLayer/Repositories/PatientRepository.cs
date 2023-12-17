using DomainLayer.Enums;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class PatientRepository : IPatientRepository
    {
        public bool SignUp(string image, string FirstName, string LastName, string email, string phone, Gender gender, DateTime dateOfBirth)
        {
            throw new NotImplementedException();
        }
        
        public bool Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public List<Doctor> GetDoctors(int Page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool GetDoctorAppointments(Appointment appointment)
        {
            throw new NotImplementedException();
        }


        public List<Booking> GetBooking()
        {
            throw new NotImplementedException();
        }


        public bool CancelBooking(int bookingId)
        {
            throw new NotImplementedException();
        }

      
     

     

      
    }
}
