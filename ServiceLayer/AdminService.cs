using DomainLayer;
using DomainLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class AdminService
    {
        private readonly IAdminRepository _adminRepository;

  

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AdminService(IAdminRepository adminRepository,
         UserManager<ApplicationUser> userManager,
         RoleManager<IdentityRole> roleManager,
         IConfiguration configuration,
         SignInManager<ApplicationUser> signInManager
         )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
           _adminRepository = adminRepository;

        }

    //  [Authorize(Roles = "Admin")]

    public async Task<SignInResult> AdminLogin(LoginRequestModel adminlogin)
        {

            // Find the user by email
            var user = await _userManager.FindByEmailAsync(adminlogin.Email);

            // Check if the user exists and validate the password
            if (user != null && await _userManager.CheckPasswordAsync(user, adminlogin.Password))
            {
                // Check if the user has the "Patient" role
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                {
                    // User is authenticated successfully and has the "Doctor" role
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return SignInResult.Success;

                }
            }

            // Authentication failed
            return SignInResult.Failed;
        }




    }
}
