using DomainLayer.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Patient: ApplicationUser
    {
        public bool IsActive;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ConfirmPassword { get; set; }

        public List<Booking> Bookings { get; set; }


        //identity refrence 
        public string UserId { get; set; }
        public ApplicationUser PatientUser { get; set; }
    }
}
