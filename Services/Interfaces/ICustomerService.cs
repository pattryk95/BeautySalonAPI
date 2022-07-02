using BeautySalonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        bool Update(int id, UpdateCustomerDto dto);
        public bool Delete(int id);
        CustomerDto GetById(int id);
        IEnumerable<CustomerDto> GetAll(string SearchPhrase);
        int Create(CreateCustomerDto dto);
    }
}
