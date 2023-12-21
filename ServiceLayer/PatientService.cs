using DomainLayer.Enums;
using DomainLayer.Models;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class PatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public bool SignUp(string image, string firstName, string lastName, string email, string phone, Gender gender, DateTime dateOfBirth)
        {
            // Additional validation and business logic can be added here if needed

            return _patientRepository.SignUp(image, firstName, lastName, email, phone, gender, dateOfBirth);
        }

        public bool Login(string email, string password)
        {
            // Additional validation and business logic can be added here if needed

            return _patientRepository.Login(email, password);
        }

        public List<Doctor> GetDoctors(DateTime searchDate, int pageSize, int pageNumber)
        {
            // Additional validation and business logic can be added here if needed

            return _patientRepository.GetDoctors(searchDate, pageSize, pageNumber);
        }
    }
}