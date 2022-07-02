using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
