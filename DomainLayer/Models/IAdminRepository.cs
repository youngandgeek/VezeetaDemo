using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public interface IAdminRepository
    {
        Task<SignInResult> Login(LoginRequestModel Adminlogin);


    }
}
