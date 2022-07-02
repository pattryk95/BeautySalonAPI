using BeautySalonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Services.Interfaces
{
    public interface IAppointmentService
    {

        IEnumerable<AppointmentDto> GetAll(string searchPhrase);
        public AppointmentDto GetById(int id);
        int Create(CreateAppointmentDto dto);
        bool Delete(int id);
        bool Update(int id, UpdateAppointmentDto dto);
    }
}
