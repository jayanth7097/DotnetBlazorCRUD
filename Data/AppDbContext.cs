using dummy.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace dummy.Data
{
    
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Seeding data
                modelBuilder.Entity<Students>().HasData(
                    new Students { StudentId = 1, Name = "Dr. Smith", Specialty = "Cardiology" },
                    new Students { StudentId = 2, Name = "Dr. Johnson", Specialty = "Neurology" }
                );

                modelBuilder.Entity<Subjects>().HasData(
                    new Subjects { SubjectId = 1, Name = "John Doe", Age = 30, Grade = "Flu", StudentId = 1 },
                    new Subjects { SubjectId = 2, Name = "Jane Roe", Age = 25, Grade = "Fracture", StudentId = 2 }
                );
            }

            public DbSet<Students> Students { get; set; } = default!;
            public DbSet<Subjects> Subjects { get; set; } = default!;

        }

    
}
