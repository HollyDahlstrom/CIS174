/*
 * ContactsAppDahlstrom
 * EF Core Web App Lab
 * 
 * This controller handles the contact management functionality:
 * - List all contacts
 * - Add a new contact
 * - Delete a contact
 *
 * Author: Holly Dahlstrom
 * Date: Jan 23, 2026
 * Course: CIS174
 */

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

        // GET: Display Delete Contact page
        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact); // sends contact to Delete page
        }

        // POST: Confirm deletion
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
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