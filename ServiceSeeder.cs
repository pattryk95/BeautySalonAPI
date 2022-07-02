using BeautySalonAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI
{
    public class ServiceSeeder
    {
        private readonly BeautySalonDbContext _dbContext;

        public ServiceSeeder(BeautySalonDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Services.Any())
                {
                    var services = GetServices();
                    _dbContext.Services.AddRange(services);
                    _dbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Service> GetServices()
        {
            var services = new List<Service>()
            {
                new Service()
                {
                    Name = "Regulacja brwi",
                    Price = 30.00M,
                    ApproximateDuration = 60
                },
                new Service()
                {
                    Name = "Manicure hybrydowy",
                    Price = 90.00M,
                    ApproximateDuration = 120
                },
                new Service()
                {
                    Name = "Depilacja laserowa",
                    Price = 200.00M,
                    ApproximateDuration = 90
                }
            };

            return services;
        }
    }
}
