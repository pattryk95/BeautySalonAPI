using BeautySalonAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI
{
    public class Seeder
    {
        private readonly BeautySalonDbContext _dbContext;
        public Seeder(BeautySalonDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.People.Any())
                {
                    var peopele = GetPeople();
                    _dbContext.People.AddRange(peopele);
                }

                if (_dbContext.Database.CanConnect())
                {
                    if (!_dbContext.Services.Any())
                    {
                        var services = GetServices();
                        _dbContext.Services.AddRange(services);
                    }
                }
                _dbContext.SaveChanges();
            }
        }

        private IEnumerable<Person> GetPeople()
        {
            var people = new List<Person>()
            {
                new Person() {
                    FirstName = "Anna",
                    LastName="Kowalska",
                    PhoneNumber="123456789",
                    Employee = new Employee()
                },
                new Person() {
                    FirstName = "Danuta",
                    LastName="Stokrotka",
                    PhoneNumber="987654321",
                    Employee = new Employee()
                },
                new Person() {
                    FirstName = "Maria",
                    LastName="Kubek",
                    PhoneNumber="987123456",
                    Employee = new Employee()
                },
                new Person() {
                    FirstName = "Irena",
                    LastName="Wiatrak",
                    PhoneNumber="456789123",
                    Customer = new Customer()
                },
                new Person() {
                    FirstName = "Hanna",
                    LastName="Wiosło",
                    PhoneNumber="321865475",
                    Customer = new Customer()
                },
            };
            return people;
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
