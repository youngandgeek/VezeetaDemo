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
        public bool SignUp(string image, string FirstName,string LastName,
            string email,string phone,Gender gender,DateTime dateOfBirth);
       // Task<IdentityResult> RegisterPatientAsync(SignupViewModel model);

        public bool Login(string email, string password);

        public List<Doctor>GetDoctors(DateTime searchDate, int pageSize, int pageNumber);






    }
}
