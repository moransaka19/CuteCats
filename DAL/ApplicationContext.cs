using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vacancy>().HasData(new[] { 
                new Vacancy()
                {
                    Id = 1,
                    Name = "Vacancy Name",
                    Price = 100000,
                    Description = "Test Description 1",
                    RecrutierName = "Recrutier Name 1",
                    PhoneNumber = "+380990000000",
                    Location = "Test Location",
                    CompanyName = "Test Name",
                }
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Vacancy> Vacancies { get; set; }
    }
}
