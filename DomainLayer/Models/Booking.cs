using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace DomainLayer.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [ForeignKey("PatientInfo")]
        public String PatientId { get; set; }
        public virtual Patient Patientinfo { get; set; }

        [ForeignKey("DoctorInfo")]
        public String DoctorId { get; set; }
        public virtual Doctor DoctorInfo { get; set; }

        [ForeignKey("Appointment")]
        public int AppointmentId{ get; set; }
        // Navigation properties to represent the relationships with Appointment
        public virtual Appointment Appointment { get; set; }

   /**     // New property to hold a list of PatientInfo with their AppointmentInfo
        public virtual List<PatientWithAppointmentInfo> PatientsWithAppointmentInfo { get; set; }
    **/
        }
}
