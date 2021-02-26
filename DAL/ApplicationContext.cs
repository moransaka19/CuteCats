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
            modelBuilder.Entity<Cat>().HasData(new[] { 
                new Cat()
                {
                    Id = 1,
                    Name = "CatName",
                    Age = 2,
                    BIO = "Smth Bio",
                    Likes = 0,
                    Photo = "Cat.jpg"
                }
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cat> Cats { get; set; }
    }
}
