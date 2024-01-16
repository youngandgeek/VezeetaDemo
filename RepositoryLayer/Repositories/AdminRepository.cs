using DomainLayer;
using DomainLayer.Enums;
using DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using RepositoryLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class AdminRepository: IAdminRepository
    {
       

        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminRepository(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Task<SignInResult> AdminLogin(LoginRequestModel Adminlogin)
        {
            throw new NotImplementedException();
        }

     /**
        public async Task<IdentityResult> AddDoctor(UserSignUpModel doctorSignUpModel)
        {
         
                try
                {
                    // Check if passwords match
                    if (doctorSignUpModel.Password != doctorSignUpModel.ConfirmPassword)
                    {
                    // Handle the case where passwords don't match
                    return IdentityResult.Failed(new IdentityError { Description = "Passwords do not match" });
                }

                // Check if user exists
                var userExist = await _userManager.FindByEmailAsync(doctorSignUpModel.Email);
                    // If exists, return error
                    if (userExist != null)
                    {
                        return IdentityResult.Failed(new IdentityError { Code = "403", Description = "Failed to sign up" });
                    }

                    // Create doctor
                    var doctor = new Doctor
                    {
                        //    UserName = patientSignUpModel.Username,
                        FullName = doctorSignUpModel.FirstName+doctorSignUpModel.LastName,
                        Email = doctorSignUpModel.Email,
                        PhoneNumber = doctorSignUpModel.Phone,
                        Specialization=doctorSignUpModel.Specialize,
                        Gender = (Gender)doctorSignUpModel.Gender,
                        DateOfBirth = (DateTime)doctorSignUpModel.DateOfBirth
                    };
                    var result = await _userManager.CreateAsync(doctor, doctorSignUpModel.Password);

                    return result;
                }
                catch (Exception ex)
                {
                    // Handle exceptions appropriately (log, throw, etc.)
                    return IdentityResult.Failed(new IdentityError { Description = "Failed to sign up." });
                }
            }
        **/

    }



}
