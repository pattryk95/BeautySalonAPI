using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Models
{
    public class UpdateServiceDto
    {
        [MaxLength(150)]
        public string? Name { get; set; }
        public int? ApproximateDuration { get; set; }
        public decimal? Price { get; set; }
    }
}
