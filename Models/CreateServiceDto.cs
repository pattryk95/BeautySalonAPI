using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Models
{
    public class CreateServiceDto
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        public int ApproximateDuration { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
