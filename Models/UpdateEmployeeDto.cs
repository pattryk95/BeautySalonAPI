using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Models
{
    public class UpdateEmployeeDto
    {
        [MaxLength(25)]
        public string? FirstName { get; set; }
        [MaxLength(25)]
        public string? LastName { get; set; }
        [MaxLength(9)]
        public string? PhoneNumber { get; set; }
        public int? SuperiorId { get; set; }

    }
}
