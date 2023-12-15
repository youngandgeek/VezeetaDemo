using DomainLayer.Enums;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Patient
    {
        public string image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        

        //identity refrence 
        public string UserId { get; set; }
        public ApplicationUser PatientUser { get; set; }

    }
}
