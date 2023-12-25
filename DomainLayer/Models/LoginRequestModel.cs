using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
  
        public class LoginRequestModel
        {
        [Required(ErrorMessage = "Please Enter your Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please Enter A Valid Password")]
        [DataType(DataType.Password)]
        public String? Password { get; set; }
    }

    }