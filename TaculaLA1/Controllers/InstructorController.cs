using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaculaLA1.Data;
using TaculaLA1.Models;
using TaculaLA1.Services;


namespace TaculaLA1.Controllers
{
    public class InstructorController : Controller
    {
        private readonly AppDBContext _dbContext;

        public InstructorController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult Index()
        {
            return View(_dbContext.Instructors);
        }

        public IActionResult ShowDetail(int id)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);
            if (instructor != null)
            {
                return View(instructor);
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
            if (!ModelState.IsValid)
                return View();

            _dbContext.Instructors.Add(newInstructor);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);
            if (instructor != null)
            {
                
                return View("EditInstructor", instructor);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditInstructor(Instructor updatedInstructor)
        {
            if (!ModelState.IsValid) { return View(); }
               
            Instructor existingInstructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == updatedInstructor.Id);

            if (existingInstructor != null)
            {
                existingInstructor.FirstName = updatedInstructor.FirstName;
                existingInstructor.LastName = updatedInstructor.LastName;
                existingInstructor.IsTenured = updatedInstructor.IsTenured;
                existingInstructor.Rank = updatedInstructor.Rank;
                existingInstructor.HiringDate = updatedInstructor.HiringDate;
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);
            if (instructor != null)
            {
              
                return View("DeleteInstructor", instructor);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteInstructor(int id)
        {
            Instructor? instructor = _dbContext.Instructors.FirstOrDefault(st => st.Id == id);
            if (instructor != null)
            {
                _dbContext.Instructors.Remove(instructor);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
