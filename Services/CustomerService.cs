using AutoMapper;
using BeautySalonAPI.Entities;
using BeautySalonAPI.Models;
using BeautySalonAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly BeautySalonDbContext _dbContext;
        private readonly IMapper _mapper;
        public CustomerService(BeautySalonDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int Create(CreateCustomerDto dto)
        {
            var person = _mapper.Map<Person>(dto);

            _dbContext.People.Add(person);
            _dbContext.SaveChanges();

            return person.Customer.Id;
        }

        public bool Delete(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(e => e.Id == id);
            if (customer is null) return false;

            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();

            return true;
        }

        public IEnumerable<CustomerDto> GetAll(string searchPhrase)
        {
            var customers = _dbContext.Customers
                .Include(e => e.Person)
                .Include(e => e.Appointments)
                .Where(
                    a => searchPhrase == null || (
                    a.Person.FirstName.ToLower().Contains(searchPhrase.ToLower()) ||
                    a.Person.LastName.ToLower().Contains(searchPhrase.ToLower())
                    ))
                .ToList();
            var customersDtos = _mapper.Map<List<CustomerDto>>(customers);

            return customersDtos;
        }

        public CustomerDto GetById(int id)
        {
            var customer = _dbContext.Customers.Include(e => e.Person).Include(e => e.Appointments).FirstOrDefault(e => e.Id == id);

            if (customer is null) return null;

            var result = _mapper.Map<CustomerDto>(customer);

            return result;
        }

        public bool Update(int id, UpdateCustomerDto dto)
        {
            var customer = _dbContext.Customers.Include(e => e.Person).FirstOrDefault(e => e.Id == id);
            if (customer is null) return false;

            customer.Person.FirstName = dto.FirstName ?? customer.Person.FirstName;
            customer.Person.LastName = dto.LastName ?? customer.Person.LastName;
            customer.Person.PhoneNumber = dto.PhoneNumber ?? customer.Person.PhoneNumber;

            _dbContext.SaveChanges();

            return true;
        }
    }
}
