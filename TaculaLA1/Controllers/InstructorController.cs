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
        [HttpGet]
        public IActionResult AddInstructor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddInstructor(Instructor newInstructor)
        {
            InstructorList.Add(newInstructor);
            return View("Index", InstructorList);
        }
        [HttpGet]
        public IActionResult EditInstructor(int id)
        {
            Instructor instructor = InstructorList.FirstOrDefault(st => st.Id == id);
            if (instructor != null)
            {
                return View(instructor);
            }

            return NotFound(); 
        }
        [HttpPost]
       
        public IActionResult EditInstructor(Instructor updatedInstructor)
        {
            // Find the existing instructor in your data source (e.g., InstructorList)
            Instructor existingInstructor = InstructorList.FirstOrDefault(st => st.Id == updatedInstructor.Id);

            
                
                existingInstructor.FirstName = updatedInstructor.FirstName;
                existingInstructor.LastName = updatedInstructor.LastName;
                existingInstructor.IsTenured = updatedInstructor.IsTenured;
                existingInstructor.Rank = updatedInstructor.Rank;
                existingInstructor.HiringDate = updatedInstructor.HiringDate;


                return View("Index", InstructorList);
            }

           
        }

    }


    

