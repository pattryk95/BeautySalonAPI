using AutoMapper;
using BeautySalonAPI.Entities;
using BeautySalonAPI.Models;
using BeautySalonAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Services
{
    public class ServiceService : IServiceService
    {
        private readonly BeautySalonDbContext _dbContext;
        private readonly IMapper _mapper;

        public ServiceService(BeautySalonDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<ServiceDto> GetAll(string searchPhrase)
        {
            var services = _dbContext.Services
                 .Where(
                    a => searchPhrase == null || (
                    a.Name.ToLower().Contains(searchPhrase.ToLower())
                    ))
                .ToList();
            var servicesDtos = _mapper.Map<List<ServiceDto>>(services);

            return servicesDtos;
        }

        public ServiceDto GetById(int id)
        {
            var service = _dbContext.Services.FirstOrDefault(s => s.Id == id);

            if (service is null) return null;

            var result = _mapper.Map<ServiceDto>(service);

            return result;
        }

        public int Create(CreateServiceDto dto)
        {
            var service = _mapper.Map<Service>(dto);

            _dbContext.Services.Add(service);
            _dbContext.SaveChanges();

            return service.Id;
        }

        public bool Delete(int id)
        {
            var service = _dbContext.Services.FirstOrDefault(s => s.Id == id);
            if (service is null) return false;

            _dbContext.Services.Remove(service);
            _dbContext.SaveChanges();

            return true;
        }

        public bool Update(int id, UpdateServiceDto dto)
        {
            var service = _dbContext.Services.FirstOrDefault(s => s.Id == id);
            if (service is null) return false;

            service.Name = dto.Name ?? service.Name;
            service.ApproximateDuration = dto.ApproximateDuration ?? service.ApproximateDuration;
            service.Price = dto.Price ?? service.Price;

            _dbContext.SaveChanges();

            return true;
        }
    }
}
