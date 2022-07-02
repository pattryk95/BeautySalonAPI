using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ApproximateDuration { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
