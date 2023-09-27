using System;
using System.Collections.Generic;
using System.Xml.Linq;
using TaculaLA1.Models;

namespace TaculaLA1.Services
{
    public class MyFakeDataService : IMyFakeDataService
    {
        public List<Instructor> InstructorList { get; }

        public List<Student> StudentList { get; } // Added StudentList

        public MyFakeDataService()
        {
            InstructorList = new List<Instructor>
            {
                new Instructor()
                {
                    Id = 1,
                    FirstName = "Karl",
                    LastName = "Tacula",
                    Rank = Rank.Professor,
                    IsTenured = IsTenured.Permanent,
                    HiringDate = new DateOnly(2002, 12, 10)
                },
                new Instructor()
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "DanielDeCastro",
                    Rank = Rank.AssistantProfessor,
                    IsTenured = IsTenured.Permanent,
                    HiringDate = new DateOnly(2020, 4, 1)
                },
                new Instructor()
                {
                    Id = 3,
                    FirstName = "Ranni",
                    LastName = "Tacula",
                    Rank = Rank.AssistantProfessor,
                    IsTenured = IsTenured.Permanent,
                    HiringDate = new DateOnly(2020, 1, 12)
                }
            };

            StudentList = new List<Student>
            {
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
            },
            };
        }
    }
}
