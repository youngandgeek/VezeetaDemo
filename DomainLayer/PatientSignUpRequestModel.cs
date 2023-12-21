using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class PatientSignUpRequestModel
    {
            public string Image { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public Gender Gender { get; set; }
            public DateTime DateOfBirth { get; set; }
        }

    }

