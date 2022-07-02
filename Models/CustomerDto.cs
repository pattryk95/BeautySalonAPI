using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }

        public PersonDto Person { get; set; }

        public List<AppointmentDto> Appointments { get; set; }
    }
}
