using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalonAPI.Entities
{
    public class BeautySalonDbContext : DbContext
    {
        private string _connectionString = "Server=.;Database=BeautySalonAPI;Trusted_Connection=True;";

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            var people = modelBuilder.Entity<Person>();
            people.Property(p => p.FirstName).IsRequired().HasMaxLength(25);
            people.Property(p => p.LastName).IsRequired().HasMaxLength(25);
            people.Property(p => p.PhoneNumber).HasMaxLength(9);

            people.HasOne<Customer>(p => p.Customer).WithOne(c => c.Person).HasForeignKey<Customer>(c => c.PersonId);
            people.HasOne<Employee>(p => p.Employee).WithOne(e => e.Person).HasForeignKey<Employee>(c => c.PersonId);

            var customers = modelBuilder.Entity<Customer>();
            customers.Property(c => c.PersonId).IsRequired();
            customers.HasMany(c => c.Appointments).WithOne(a => a.Customer);

            var employees = modelBuilder.Entity<Employee>();
            employees.Property(e => e.PersonId).IsRequired();
            employees.HasMany(e => e.Appointments).WithOne(a => a.Employee);

            var appointments = modelBuilder.Entity<Appointment>();
            appointments.Property(a => a.Date).IsRequired();

            var services = modelBuilder.Entity<Service>();
            services.Property(s => s.Name).IsRequired().HasMaxLength(150);
            services.Property(s => s.ApproximateDuration).IsRequired();
            services.Property(s => s.Price).IsRequired().HasPrecision(9,2);
            services.HasMany(s => s.Appointments).WithOne(a => a.Service);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
