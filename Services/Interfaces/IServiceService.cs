using BeautySalonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Services.Interfaces
{
    public interface IServiceService
    {
        bool Update(int id, UpdateServiceDto dto);
        public bool Delete(int id);
        ServiceDto GetById(int id);
        IEnumerable<ServiceDto> GetAll(string searchPhrase);
        int Create(CreateServiceDto dto);
    }
}
