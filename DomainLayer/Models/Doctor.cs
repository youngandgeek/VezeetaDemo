using DomainLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Doctor: ApplicationUser
    {
        public bool IsActive;

        public string FullName { get; set; }
        public string Specialization { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")] 
        public decimal Price { get; set; }

        // Navigation property for appointments
        public ICollection<Appointment> Appointments { get; set; }
        public List<Booking> Bookings { get; set; }

        //identity refrence 
        public string UserId { get; set; }
        public ApplicationUser DoctorUser { get; set; }
    }
}
