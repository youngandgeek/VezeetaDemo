using DomainLayer;
using DomainLayer.Enums;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
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

        public async Task<IdentityResult> SignUp(PatientSignUpModel patientSignUpModel)
        {
            // Additional validation and business logic can be added here if needed
            return await _patientRepository.SignUp(patientSignUpModel);
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