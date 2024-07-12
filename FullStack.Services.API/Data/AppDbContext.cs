using FullStack.Services.API.Model;
using Microsoft.EntityFrameworkCore;

namespace FullStack.Services.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Student>().HasData(
              new Student
              {
                  StudentId = 1,
                  FirstName = "John",
                  LastName = "Doe",
                  Age = 20,
                  EnrollmentDate = new DateTime(2023, 9, 1)
              },
              new Student
              {
                  StudentId = 2,
                  FirstName = "Jane",
                  LastName = "Smith",
                  Age = 22,
                  EnrollmentDate = new DateTime(2023, 9, 1)
              }
          );

        }
    }
}
