using System;
using System.ComponentModel.DataAnnotations;

namespace TaculaLA1.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Course is required")]
        [Display(Name = "Course")]
        public Course Course { get; set; }
        [Required(ErrorMessage = "Hiring Date is required")]
        public DateTime DateEnrolled { get; set; }
    }

    public enum Course
    {
        BSIT,
        BSCS,
        BSIS
    }
}
