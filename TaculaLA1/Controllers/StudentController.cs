using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TaculaLA1.Data;
using TaculaLA1.Models;
using TaculaLA1.Services;

namespace TaculaLA1.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDBContext _dbContext;

        public StudentController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult Index()
        {
            return View(_dbContext.Instructors);
        }

        public IActionResult ShowDetail(int id)
        {
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);
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
            _dbContext.Students.Add(newStudent);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditStudent(int id)
        {
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);
            if (student != null)
            {
                return View("EditStudent", student);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditStudent(Student updatedStudent)
        {
            Student existingStudent = _dbContext.Students.FirstOrDefault(st => st.Id == updatedStudent.Id);

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
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);
            if (student != null)
            {
                return View("DeleteStudent", student);
            }

            return NotFound();
        }


        [HttpPost]
        public IActionResult DeleteStudent(int id)
        {
            Student? student = _dbContext.Students.FirstOrDefault(st => st.Id == id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
