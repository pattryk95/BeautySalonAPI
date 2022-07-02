using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Models
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public EmployeeDto Employee { get; set; }

        public CustomerDto Customer { get; set; }

        public ServiceDto Service { get; set; }

    }
}
