using AutoMapper;
using BeautySalonAPI.Entities;
using BeautySalonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI
{
    public class BeautySalonMappingProfile : Profile
    {
        public BeautySalonMappingProfile()
        {
            CreateMap<Person, PersonDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Appointment, AppointmentDto>();
            CreateMap<Service, ServiceDto>();

            CreateMap<CreateEmployeeDto, Person>().
                ForMember(e => e.Employee, c => c.MapFrom(dto => new Employee()));

            CreateMap<CreateCustomerDto, Person>().
                ForMember(e => e.Customer, c => c.MapFrom(dto => new Customer()));
            CreateMap<CreateServiceDto, Service>();
            CreateMap<CreateAppointmentDto, Appointment>();

        }
    }
}
