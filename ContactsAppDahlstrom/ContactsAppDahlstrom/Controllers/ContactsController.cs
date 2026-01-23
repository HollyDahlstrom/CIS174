using Microsoft.AspNetCore.Mvc;
using ContactsAppDahlstrom.Data;
using ContactsAppDahlstrom.Models;

namespace ContactsAppDahlstrom.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // LIST CONTACTS
        public IActionResult Index()
        {
            return View(_context.Contacts.ToList());
        }

        // ADD CONTACT (GET)
        public IActionResult Create()
        {
            return View();
        }

        // ADD CONTACT (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // DELETE CONTACT
        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}