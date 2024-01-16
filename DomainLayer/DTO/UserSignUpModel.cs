using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class UserSignUpModel
    {
        //  public string? Image { get; set; }
        /**{image,firstName,lastName,email,phone,specialize,gender,dateOfBirth}	**/

        [Required(ErrorMessage ="Please Enter your First Name")]
  [MaxLength(255)]
  public String? FirstName { get; set; }
  
        [Required(ErrorMessage = "Please Enter your Last Name")]
  [MaxLength(255)]
  public String? LastName { get; set; }

        [Required (ErrorMessage ="Please Enter your Email")]
  [DataType(DataType.EmailAddress)]
  public string? Email { get; set; }

  [DataType(DataType.PhoneNumber)]
  [Required(ErrorMessage = "Please Enter your Phone")]
  public string? Phone { get; set; }

 public String? Specialize { get; set; }

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

