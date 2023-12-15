using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Doctor
    {
        public string image { get; set; }
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public decimal Price { get; set; }

        // Navigation property for appointments
        public ICollection<Appointment> Appointments { get; set; }

        //identity refrence 
        public string UserId { get; set; }
        public ApplicationUser DoctorUser { get; set; }
    }
}
