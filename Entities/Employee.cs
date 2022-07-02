using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BeautySalonAPI.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public int? SuperiorId { get; set; }
        public virtual Employee Superior { get; set; }

        public virtual List<Appointment> Appointments { get; set; }
    }
}
