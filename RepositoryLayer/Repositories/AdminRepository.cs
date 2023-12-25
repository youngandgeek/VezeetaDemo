using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        public async Task<SignInResult> Login(LoginRequestModel Adminlogin)
        {

            // The Login method is implemented in the PatientService.
            throw new NotImplementedException("Login method is not implemented in PatientRepository.");
        }
    }



}
