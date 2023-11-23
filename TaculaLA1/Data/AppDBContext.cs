using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using TaculaLA1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TaculaLA1.Data
{
    public class AppDBContext : IdentityDbContext<User>
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Instructor> Instructors { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext>options ):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    Name = "No El",
                    Course = Course.BSIT,
                    DateEnrolled = DateTime.Parse("17/09/2021")
                },
            new Student()
            {
                Id = 2,
                Name = "Clara Magnolia",
                Course = Course.BSCS,
                DateEnrolled = DateTime.Parse("8/12/2002")
            },
            new Student()
            {
                Id = 3,
                Name = "Virgil",
                Course = Course.BSIS,
                DateEnrolled = DateTime.Parse("23/09/2002")
            }
                );


            modelBuilder.Entity<Instructor>().HasData(
                new Instructor()
                {
                    Id = 1,
                    FirstName = "Karl",
                    LastName = "Tacula",
                    Rank = Rank.Professor,
                    IsTenured = IsTenured.Permanent,
                    HiringDate = DateTime.Parse("23/09/2002")
                },
                new Instructor()
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "DanielDeCastro",
                    Rank = Rank.AssistantProfessor,
                    IsTenured = IsTenured.Permanent,
                    HiringDate = DateTime.Parse("23/09/2001")
                },
                new Instructor()
                {
                    Id = 3,
                    FirstName = "Ranni",
                    LastName = "Tacula",
                    Rank = Rank.AssistantProfessor,
                    IsTenured = IsTenured.Permanent,
                    HiringDate = DateTime.Parse("23/09/2002")
                });
            }

        }
        }
    
