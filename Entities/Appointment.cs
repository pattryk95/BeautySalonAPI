using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

    }
}
