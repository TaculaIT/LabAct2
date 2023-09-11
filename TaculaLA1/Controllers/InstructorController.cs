using Microsoft.AspNetCore.Mvc;
using TaculaLA1.Models;

namespace TaculaLA1.Controllers
{
    public class InstructorController : Controller
    {
        List<Instructor> InstructorList = new List<Instructor>
        {
            new Instructor()
            {
                Id = 1,
                FirstName = "Karl",
                LastName = "Tacula",
                Rank = Rank.Professor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateOnly.Parse("12/10/2002")
            },
            new Instructor()
            {
                Id = 2,
                FirstName = "John",
                LastName = "DanielDeCastro",
                Rank = Rank.AssistantProfessor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateOnly.Parse("04/01/2020")
            },
            new Instructor()
            {
                Id = 3,
                FirstName = "Ranni",
                LastName = "Tacula",
                Rank = Rank.AssistantProfessor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateOnly.Parse("01/12/2020")
            },
            new Instructor()
            {
                Id = 4,
                FirstName = "Katy",
                LastName = "Perry",
                Rank = Rank.Instructor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateOnly.Parse("01/12/0001")
            },
            new Instructor()
            {
                Id = 5,
                FirstName = "Dan",
                LastName = "TDM",
                Rank = Rank.AssociateProfessor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateOnly.Parse("08/9/0007")
            },
            new Instructor()
            {
                Id = 6,
                FirstName = "Mel",
                LastName = "Fredfonclara",
                Rank = Rank.Professor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateOnly.Parse("12/10/2002")
            },
            new Instructor()
            {
                Id = 7,
                FirstName = "Shanty",
                LastName = "Dope",
                Rank = Rank.Professor,
                IsTenured = IsTenured.Probationary,
                HiringDate = DateOnly.Parse("9/11/2002")
            },
            new Instructor()
            {
                Id = 8,
                FirstName = "Mel",
                LastName = "Tiangco",
                Rank = Rank.Instructor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateOnly.Parse("11/12/2001")
            },
            new Instructor()
            {
                Id = 9,
                FirstName = "King",
                LastName = "Philips",
                Rank = Rank.AssociateProfessor,
                IsTenured = IsTenured.Permanent,
                HiringDate = DateOnly.Parse("01/7/1999")
            },
            new Instructor()
            {
                Id = 10,
                FirstName = "Benedict",
                LastName = "Cumbingberch",
                Rank = Rank.Instructor,
                IsTenured = IsTenured.Probationary,
                HiringDate = DateOnly.Parse("01/11/2020")
            },
        };
        public IActionResult Index()
        {
            return View(InstructorList);
        }

        public IActionResult ShowDetail(int id)
        {
            Instructor? Instructor = InstructorList.FirstOrDefault(st => st.Id == id);
            if (Instructor != null)
            {
                return View(Instructor);
            }

            return View();
        }


    }
}

    

