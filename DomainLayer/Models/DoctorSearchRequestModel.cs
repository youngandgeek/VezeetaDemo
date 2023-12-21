using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class DoctorSearchRequestModel
    {
        public DateTime SearchDate { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
