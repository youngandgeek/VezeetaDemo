using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        // Foreign key property to associate with a doctor
        /**  [ForeignKey("Doctor")]
          public int DoctorId { get; set; }
          // Navigation property to represent the relationship with a doctor
     //     public Doctor Doctors { get; set; }
      
         **/

    }
}
