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
private readonly SignInManager<ApplicationUser> _signInManager;

   public PatientService( IPatientRepository patientRepository,
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager,
    IConfiguration configuration,
    SignInManager<ApplicationUser> signInManager
    )
{
    _patientRepository = patientRepository;
    _userManager = userManager;
    _roleManager = roleManager;
    _configuration = configuration;
    _signInManager = signInManager;
}



   public async Task<IdentityResult> SignUp(UserSignUpModel patientSignUpModel)
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


        public async Task<SignInResult> PatientLogin(LoginRequestModel patientLogin)
        {
            // Find the user by email
            var user = await _userManager.FindByEmailAsync(patientLogin.Email);

            // Check if the user exists and validate the password
            if (user != null && await _userManager.CheckPasswordAsync(user, patientLogin.Password))
            {
                // Check if the user has the "Patient" role
                if (await _userManager.IsInRoleAsync(user, "Patient"))
                {
                    // User is authenticated successfully and has the "Doctor" role
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return SignInResult.Success;

                }
            }

            // Authentication failed
            return SignInResult.Failed;
        }


        //find the user by email

    /**    public List<Doctor> GetDoctors(DateTime searchDate, int pageSize, int pageNumber)
{
    // Additional validation and business logic can be added here if needed

    return _patientRepository.GetDoctors(searchDate, pageSize, pageNumber);
}
    **/
}
}