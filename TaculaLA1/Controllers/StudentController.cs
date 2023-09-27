using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaculaLA1.Models;
using TaculaLA1.Services;

namespace TaculaLA1.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMyFakeDataService _fakeData;

        public StudentController(IMyFakeDataService fakeData)
        {
            _fakeData = fakeData;
        }

        public IActionResult Index()
        {
            return View(_fakeData.StudentList);
        }

        public IActionResult ShowDetail(int id)
        {
            Student? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);
            if (student != null)
            {
                return View(student);
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddStudent(Student newStudent)
        {
            _fakeData.StudentList.Add(newStudent);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            Student? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);
            if (student != null)
            {
                return View("EditStudent", student);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditStudent(Student updatedStudent)
        {
            Student existingStudent = _fakeData.StudentList.FirstOrDefault(st => st.Id == updatedStudent.Id);

            if (existingStudent != null)
            {
                existingStudent.Name = updatedStudent.Name;
                existingStudent.Course = updatedStudent.Course;
                existingStudent.DateEnrolled = updatedStudent.DateEnrolled;

                // Redirect back to the updated student list
                return RedirectToAction("Index");
            }

            return NotFound();
        }


        [HttpGet]
        public IActionResult DeleteConfirmation(int id)
        {
            Student? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);
            if (student != null)
            {
                return View("DeleteStudent", student);
            }

            return NotFound();
        }


        [HttpPost]
        public IActionResult DeleteStudent(int id)
        {
            Student? student = _fakeData.StudentList.FirstOrDefault(st => st.Id == id);
            if (student != null)
            {
                _fakeData.StudentList.Remove(student);
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
