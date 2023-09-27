using Microsoft.AspNetCore.Mvc;
using TaculaLA1.Models;
using TaculaLA1.Services;

namespace TaculaLA1.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IMyFakeDataService _fakeData;

        public InstructorController(IMyFakeDataService fakeData)
        {
            _fakeData = fakeData;
        }

        public IActionResult Index()
        {
            return View(_fakeData.InstructorList);
        }

        public IActionResult ShowDetail(int id)
        {
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == id);
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
            _fakeData.InstructorList.Add(newInstructor);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == id);
            if (instructor != null)
            {
                
                return View("EditInstructor", instructor);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditInstructor(Instructor updatedInstructor)
        {
            Instructor existingInstructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == updatedInstructor.Id);

            if (existingInstructor != null)
            {
                existingInstructor.FirstName = updatedInstructor.FirstName;
                existingInstructor.LastName = updatedInstructor.LastName;
                existingInstructor.IsTenured = updatedInstructor.IsTenured;
                existingInstructor.Rank = updatedInstructor.Rank;
                existingInstructor.HiringDate = updatedInstructor.HiringDate;

                return RedirectToAction("Index");
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == id);
            if (instructor != null)
            {
              
                return View("DeleteInstructor", instructor);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult DeleteInstructor(int id)
        {
            Instructor? instructor = _fakeData.InstructorList.FirstOrDefault(st => st.Id == id);
            if (instructor != null)
            {
                _fakeData.InstructorList.Remove(instructor);
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
