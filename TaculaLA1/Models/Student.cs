using System;

namespace TaculaLA1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Course Course { get; set; }
        public DateTime DateEnrolled { get; set; }
    }

    public enum Course
    {
        BSIT,
        BSCS,
        BSIS
    }
}
