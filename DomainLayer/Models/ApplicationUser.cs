using DomainLayer.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public string Image { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name must be at most 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name must be at most 50 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]

        [NotMapped]
        public string ConfirmPassword { get; set; }

        // Additional properties for your application's user
        public string FullName => $"{FirstName} {LastName}";

        public Gender Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(100, ErrorMessage = "Specialization must be at most 100 characters.")]
        public string? Specialization { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }




        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please Enter your Phone")]
        public string? Phone { get; set; }
    }
}
