using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
namespace DomainLayer
{
  public interface IAdminRepository
    {
        Task<SignInResult> AdminLogin(LoginRequestModel Adminlogin);

        //  Task<IdentityResult> AddDoctor(UserSignUpModel doctorSignUpModel);

    }

}
