using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class PatientSignUpModel
    {
      //  public string? Image { get; set; }

        [Required(ErrorMessage = "Username Is Required")]
        public string Username { get; set; }

        [Required (ErrorMessage ="Please Enter your Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
      
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please Enter your Phone")]
        public string? Phone { get; set; }

        public Gender? Gender { get; set; }

        [Required(ErrorMessage = "Please Enter your Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
     
        [Required(ErrorMessage = "Please Enter A Valid Password")]
        [DataType(DataType.Password)]
        public String? Password { get; set; }

        [Required(ErrorMessage ="Please Retype your Password")]
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public string? ConfirmPassword { get; set; }
   
        }

    }

