using Ch04MovieListDahlstrom.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Ch04MovieListDahlstrom.Controllers
{
    // Controller for Assignment 6.1
    // Handles displaying student list based on access level
    public class Assignment61Controller : Controller
    {
        // Index action displays students based on accessLevel route parameter
        public IActionResult Index(int accessLevel)
        {
            // Validates accessLevel to make sure between 1 & 10
            if (accessLevel < 1 || accessLevel > 10)
            {
                return Content("Access level must be between 1 and 10.");
            }
            // Sets welcome message: Admin if accessLevel >= 8, otherwise Student
            ViewBag.Name = (accessLevel >= 8) ? "Admin" : "Student";

            // List of students for assignment
            var students = new List<Student>
    {
        new Student { StudentId = 1, FirstName = "Jane", LastName = "Doe", Grade = 100 },
        new Student { StudentId = 2, FirstName = "Fredrik", LastName = "Nilsson", Grade = 85 },
        new Student { StudentId = 3, FirstName = "John", LastName = "Doe", Grade = 90 },
        new Student { StudentId = 4, FirstName = "Holly", LastName = "Dahlstrom", Grade = 100},
        new Student { StudentId = 5, FirstName = "Anna", LastName = "Gradiska", Grade = 99},
        new Student { StudentId = 6, FirstName = "Andreas", LastName = "Dahlstrom", Grade = 98}
    };
            // ViewModel contains both students & accessLevel
            var viewModel = new StudentViewModel
            {
                Students = students,
                AccessLevel = accessLevel
            };
            // Passes ViewModel to Razor view
            return View(viewModel);
        }
    }
}