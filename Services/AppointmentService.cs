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
    public class AppointmentService : IAppointmentService
    {
        private readonly BeautySalonDbContext _dbContext;
        private readonly IMapper _mapper;

        public AppointmentService(BeautySalonDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<AppointmentDto> GetAll(string searchPhrase)
        {
            var appointments = _dbContext.Appointments
                .Include(c => c.Customer).ThenInclude(p => p.Person)
                .Include(e => e.Employee).ThenInclude(p => p.Person)
                .Include(s => s.Service)
                .Where(
                    a => searchPhrase == null || (
                    a.Service.Name.ToLower().Contains(searchPhrase.ToLower()) ||
                    a.Customer.Person.FirstName.ToLower().Contains(searchPhrase.ToLower()) ||
                    a.Customer.Person.LastName.ToLower().Contains(searchPhrase.ToLower()) ||
                    a.Employee.Person.FirstName.ToLower().Contains(searchPhrase.ToLower()) ||
                    a.Employee.Person.LastName.ToLower().Contains(searchPhrase.ToLower()
                    )))
                .ToList();
            var appointmentsDtos = _mapper.Map<List<AppointmentDto>>(appointments);

            return appointmentsDtos;
        }

        public AppointmentDto GetById(int id)
        {
            var appointment = _dbContext.Appointments
                                .Include(c => c.Customer).ThenInclude(p => p.Person)
                                .Include(e => e.Employee).ThenInclude(p => p.Person)
                                .Include(s => s.Service)
                                .FirstOrDefault(a => a.Id == id);

            if (appointment is null) return null;

            var result = _mapper.Map<AppointmentDto>(appointment);

            return result;
        }

        public int Create(CreateAppointmentDto dto)
        {
            var appointment = _mapper.Map<Appointment>(dto);

            _dbContext.Appointments.Add(appointment);
            _dbContext.SaveChanges();

            return appointment.Id;
        }

        public bool Delete(int id)
        {
            var appointment = _dbContext.Appointments.FirstOrDefault(a => a.Id == id);
            if (appointment is null) return false;

            _dbContext.Appointments.Remove(appointment);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Update(int id, UpdateAppointmentDto dto)
        {
            var appointment = _dbContext.Appointments.FirstOrDefault(a => a.Id == id);
            if (appointment is null) return false;

            appointment.Date = dto.Date ?? appointment.Date;
            appointment.EmployeeId = dto.EmployeeId ?? appointment.EmployeeId;
            appointment.CustomerId = dto.CustomerId ?? appointment.CustomerId;
            appointment.ServiceId = dto.ServiceId ?? appointment.ServiceId;

            _dbContext.SaveChanges();

            return true;
        }
    }
}
