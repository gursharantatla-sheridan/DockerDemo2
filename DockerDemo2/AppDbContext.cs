using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DockerDemo2
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn =
                "Server=sqlserver;" +
                "Database=StudentDB;" +
                "User Id=sa;" +
                "Password=Password123!;" +
                "TrustServerCertificate=True;";

            Console.WriteLine(conn);

            optionsBuilder.UseSqlServer(conn, options => options.EnableRetryOnFailure());
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "John", Program = "COMP" },
                new Student { Id = 2, Name = "Anne", Program = "BUSI" },
                new Student { Id = 3, Name = "Mark", Program = "ENGG" }
            );
        }
    }
}
