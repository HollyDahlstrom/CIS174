// Name: Holly Dahlstrom
// Class: DMACC CIS 174
// Date: 1/15/2026
// Assignment: First Responsive Web App
// Description: Handles GET and POST requests for the Age Calculator.

using Microsoft.AspNetCore.Mvc;
using FirstResponsiveWebAppDahlstrom.Models;

namespace FirstResponsiveWebAppDahlstrom.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Age = null;
            ViewBag.AgeToday = null;
            return View();
        }

        [HttpPost]
        public IActionResult Index(BirthdayModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Age = model.AgeThisYear();
                ViewBag.AgeToday = model.AgeToday();
            }
            else
            {
                ViewBag.Age = null;
                ViewBag.AgeToday = null;
            }

            return View(model);
        }
    }
}