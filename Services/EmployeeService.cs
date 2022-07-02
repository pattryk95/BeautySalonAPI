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
    public class EmployeeService : IEmployeeService
    {
        private readonly BeautySalonDbContext _dbContext;
        private readonly IMapper _mapper;
        public EmployeeService(BeautySalonDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool Update(int id, UpdateEmployeeDto dto)
        {
            var employee = _dbContext.Employees.Include(e => e.Person).FirstOrDefault(e => e.Id == id);
            if (employee is null) return false;

            employee.Person.FirstName = dto.FirstName ?? employee.Person.FirstName;
            employee.Person.LastName = dto.LastName ?? employee.Person.LastName;
            employee.Person.PhoneNumber = dto.PhoneNumber ?? employee.Person.PhoneNumber;
            employee.SuperiorId = dto.SuperiorId ?? employee.SuperiorId;

            _dbContext.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (employee is null) return false;

            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();

            return true;
        }

        public EmployeeDto GetById(int id)
        {
            var employee = _dbContext.Employees.Include(e => e.Person).Include(e => e.Superior).Include(e => e.Appointments).FirstOrDefault(e => e.Id == id);

            if (employee is null) return null;

            var result = _mapper.Map<EmployeeDto>(employee);

            return result;
        }

        public IEnumerable<EmployeeDto> GetAll(string searchPhrase)
        {
            var employees = _dbContext.Employees
                .Include(e => e.Person)
                .Include(e => e.Superior)
                .Include(e => e.Appointments)
                .Where(
                    a => searchPhrase == null || (
                    a.Person.FirstName.ToLower().Contains(searchPhrase.ToLower()) ||
                    a.Person.LastName.ToLower().Contains(searchPhrase.ToLower()) ||
                    a.Superior.Person.FirstName.ToLower().Contains(searchPhrase.ToLower()) ||
                    a.Superior.Person.LastName.ToLower().Contains(searchPhrase.ToLower())
                    ))
                .ToList();
            var employeesDtos = _mapper.Map<List<EmployeeDto>>(employees);

            return employeesDtos;
        }

        public int Create(CreateEmployeeDto dto)
        {
            var person = _mapper.Map<Person>(dto);

            _dbContext.People.Add(person);
            _dbContext.SaveChanges();

            return person.Employee.Id;
        }
    }
}
