using DomainLayer.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class ApplicationUser : IdentityUser
    {
      
            // Additional properties for your application's user
        public string FullName { get; set; }
        public Gender gender { get; set; }
        public DateTime dateOfBirth { get; set; }


        // Navigation property to Patient
          public Patient PatientProfile { get; set; }

           // Navigation property to Doctor
           public Doctor DoctorProfile { get; set; }



    }
}
