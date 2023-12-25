using DomainLayer;
using DomainLayer.Enums;
using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
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

 //instead of adding the constructor with all those properties in controller add it here and add 
/** IN CONTROLER 
 * private readonly PatientService _patientService;

public PatientController(PatientService patientService)
{
_patientService = patientService;
} **
/**AND INHECT IN STARTUP.CS ConfigureServices {
 services.AddScoped<PatientService>();
    services.AddScoped<IPatientRepository, PatientRepository>();
**/

private readonly IPatientRepository _patientRepository;
private readonly UserManager<ApplicationUser> _userManager;
private readonly RoleManager<IdentityRole> _roleManager;
private readonly IConfiguration _configuration;

public PatientService(
    IPatientRepository patientRepository,
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager,
    IConfiguration configuration)
{
    _patientRepository = patientRepository;
    _userManager = userManager;
    _roleManager = roleManager;
    _configuration = configuration;
}



   public async Task<IdentityResult> SignUp(PatientSignUpModel patientSignUpModel)
        {
            //check if user exist 

            var userExist = await _userManager.FindByEmailAsync(patientSignUpModel.Email);
            //if exists return ex
            if (userExist != null)
            {
                return IdentityResult.Failed(new IdentityError { Code = "403", Description = "Failed to sign up" });

            }
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
                    return IdentityResult.Failed(new IdentityError { Description = "Failed to sign up" });

                }
            

            }


        public async Task<IdentityResult> Login(LoginRequestModel Patientlogin)
        {  //find the user by email
            var user = await _userManager.FindByEmailAsync(Patientlogin.Email);

            //check if the user exists, password validation
            if (user != null && await _userManager.CheckPasswordAsync(user, Patientlogin.Password))
            {
                // User is authenticated successfully
                var roles = await _userManager.GetRolesAsync(user);

                return IdentityResult.Success;
            }

            //else return Authentication failed
            return IdentityResult.Failed(new IdentityError { Description = "Failed to Login Check Emain or Password" });

        }

public List<Doctor> GetDoctors(DateTime searchDate, int pageSize, int pageNumber)
{
    // Additional validation and business logic can be added here if needed

    return _patientRepository.GetDoctors(searchDate, pageSize, pageNumber);
}
}
}