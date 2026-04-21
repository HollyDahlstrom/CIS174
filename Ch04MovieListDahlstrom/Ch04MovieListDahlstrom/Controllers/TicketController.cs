using Microsoft.AspNetCore.Mvc;
using Ch04MovieListDahlstrom.Models;
using Ch04MovieListDahlstrom.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Ch04MovieListDahlstrom.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly ITicketRepository _repo;
        private readonly TicketContext _context; 

        public TicketController(ITicketRepository repo, TicketContext context)
        {
            _repo = repo;
            _context = context;
        }

        // Index action with optional status filter
        public IActionResult Index(string statusFilter)
        {
            ViewBag.Statuses = _context.Statuses.ToList();

            var tickets = _repo.GetAllTickets();

            // Apply filter
            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "all")
            {
                tickets = tickets
                    .Where(t => t.StatusId == statusFilter)
                    .ToList();
            }

            ViewBag.StatusFilter = statusFilter ?? "all";

            return View(tickets);
        }

        // Delete completed
        [HttpPost]
        public IActionResult DeleteCompleted()
        {
            var completed = _repo.GetAllTickets()
                .Where(t => t.StatusId == "Done")
                .ToList();

            foreach (var ticket in completed)
            {
                _repo.DeleteTicket(ticket);
            }

            _repo.Save();

            return RedirectToAction("Index");
        }

        // GET Add
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Statuses = _context.Statuses.ToList();
            return View(new Ticket());
        }

        // POST Add
        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _repo.InsertTicket(ticket);
                _repo.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Statuses = _context.Statuses.ToList();
            return View(ticket);
        }
    }
}