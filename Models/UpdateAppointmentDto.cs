using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Models
{
    public class UpdateAppointmentDto
    {
        public DateTime? Date { get; set; }
        public int? EmployeeId { get; set; }
        public int? CustomerId { get; set; }
        public int? ServiceId { get; set; }
    }
}
