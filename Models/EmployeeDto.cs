using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Models
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public PersonDto Person { get; set; }

        public EmployeeDto Superior { get; set; }

        public List<AppointmentDto> Appointments { get; set; }
    }
}
