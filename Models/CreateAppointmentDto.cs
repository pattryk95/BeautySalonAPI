using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Models
{
    public class CreateAppointmentDto
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int ServiceId { get; set; }
    }
}
