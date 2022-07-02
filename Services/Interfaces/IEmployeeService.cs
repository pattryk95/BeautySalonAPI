using BeautySalonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Services.Interfaces
{
    public interface IEmployeeService
    {
        bool Update(int id, UpdateEmployeeDto dto);
        public bool Delete(int id);
        EmployeeDto GetById(int id);
        IEnumerable<EmployeeDto> GetAll(string searchPhrase);
        int Create(CreateEmployeeDto dto);
    }
}
