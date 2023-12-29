using DomainLayer;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class AdminService
    {
      //  private readonly IAdminRepository _iAdminRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AdminService(
         UserManager<ApplicationUser> userManager,
         RoleManager<IdentityRole> roleManager,
         IConfiguration configuration,
         SignInManager<ApplicationUser> signInManager
         )
        {
         //   _iAdminRepository = iAdminRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }

        //seed an admin into the db
        public void SeedAdminUser()
        {
            // Seed roles if not already seeded
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                _roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
            }

            // Seed admin user
            var adminUser = new ApplicationUser
            {
                UserName = "admin@vezeeta.com",
                Email = "admin@vezeeta.com",
               // EmailConfirmed = true
            };

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin@123V");

            _userManager.CreateAsync(adminUser).Wait();

            // Assign the admin user to the "Admin" role
            var adminRoleId = _roleManager.Roles.FirstOrDefault(r => r.Name == "Admin")?.Id;

            if (adminRoleId != null)
            {
                _userManager.AddToRoleAsync(adminUser, "Admin").Wait();
            }
        }

        [Authorize(Roles = "Admin")]

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> Login(LoginRequestModel Adminlogin)
        {
            // Find the user by email
            var user = await _userManager.FindByEmailAsync(Adminlogin.Email);

            // Check if the user exists and validate the password
            if (user != null && await _userManager.CheckPasswordAsync(user, Adminlogin.Password))
            {
                // Check if the user has the "Doctor" role
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    // User is authenticated successfully and has the "Doctor" role
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Microsoft.AspNetCore.Identity.SignInResult.Success;
                }
            }
            // Authentication failed or user doesn't have the "Doctor" role
            return Microsoft.AspNetCore.Identity.SignInResult.Failed;


        }






        /**Doctor creation Up by admin

                public async Task<IdentityResult> CreateDoctor(DoctorSignUpModel doctorSignUpModel)
                {
                    // Check if passwords match
                    if (patientSignUpModel.Password != patientSignUpModel.ConfirmPassword)
                    {
                        // Handle the case where passwords don't match
                        return IdentityResult.Failed(new IdentityError { Description = "Passwords do not match" });
                    }

                    // Call the repository to handle signup logic
                    var result = await _patientRepository.SignUp(patientSignUpModel);

                    if (result.Succeeded)
                    {
                        // Check if the "Patient" role exists before adding
                        if (await _roleManager.RoleExistsAsync("Patient"))
                        {
                            // Retrieve the user by email after signing up
                            var patient = await _userManager.FindByEmailAsync(patientSignUpModel.Email);

                            if (patient != null)
                            {
                                // Add the "Patient" role to the user
                                var addToRoleResult = await _userManager.AddToRoleAsync(patient, "Patient");

                                if (addToRoleResult.Succeeded)
                                {
                                    // Success
                                    return IdentityResult.Success;
                                }
                                else
                                {
                                    // Handle the case where adding the role was not successful
                                    return IdentityResult.Failed(new IdentityError { Description = "Failed to sign up" });
                                }
                            }
                            else
                            {
                                // Handle the case where the user was not found after signing up
                                return IdentityResult.Failed(new IdentityError { Description = "User not found after signing up" });
                            }
                        }
                        else
                        {
                            // Handle the case where the "Patient" role doesn't exist
                            return IdentityResult.Failed(new IdentityError { Description = "Role 'Patient' does not exist" });
                        }
                    }
                    else
                    {
                        // Handle the case where signup was not successful
                        return IdentityResult.Failed(new IdentityError { Description = "Failed to sign up" });
                    }
                }
        **/

    }
}
