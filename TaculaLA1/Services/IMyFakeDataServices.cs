using System.Collections.Generic;
using TaculaLA1.Models;
using TaculaLA1.Services;

namespace TaculaLA1.Services
{
    public interface IMyFakeDataService
    {
        List<Instructor> InstructorList { get; }
        List<Student> StudentList { get; }
    }
}
