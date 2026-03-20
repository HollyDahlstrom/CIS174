using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ch04MovieListDahlstrom.Models;

namespace Ch04MovieListDahlstrom.Controllers
{
    public class TicketController : Controller
    {
        private readonly TicketContext _context;

        public TicketController(TicketContext context)
        {
            _context = context;
        }

        // Index action with optional status filter
        public async Task<IActionResult> Index(string statusFilter)
        {
            // Loads statuses for dropdown
            ViewBag.Statuses = await _context.Statuses.ToListAsync();

            // Starts query
            IQueryable<Ticket> query = _context.Tickets.Include(t => t.Status);

            // Applies status filter
            if (!string.IsNullOrEmpty(statusFilter) && statusFilter != "all")
            {
                query = query.Where(t => t.Status.Name == statusFilter);
            }

            var tickets = await query.OrderBy(t => t.TicketId).ToListAsync();
            ViewBag.StatusFilter = statusFilter ?? "all";

            return View(tickets);
        }

        // Deletes all completed tickets
        [HttpPost]
        public async Task<IActionResult> DeleteCompleted()
        {
            var completed = await _context.Tickets
                .Include(t => t.Status)
                .Where(t => t.Status.Name == "Done")
                .ToListAsync();

            if (completed.Any())
            {
                _context.Tickets.RemoveRange(completed);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        // Adds ticket GET
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Statuses = _context.Statuses.ToList();
            var ticket = new Ticket { Status = _context.Statuses.FirstOrDefault()! };
            return View(ticket);
        }

        // Adds ticket POST
        [HttpPost]
        public async Task<IActionResult> Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Statuses = _context.Statuses.ToList();
            return View(ticket);
        }
    }
}