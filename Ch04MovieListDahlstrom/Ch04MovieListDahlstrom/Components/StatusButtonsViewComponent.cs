using Microsoft.AspNetCore.Mvc;
using Ch04MovieListDahlstrom.Models;

namespace Ch04MovieListDahlstrom.Components
{
    public class StatusButtonsViewComponent : ViewComponent
    {
        private readonly TicketContext _context;

        public StatusButtonsViewComponent(TicketContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var statuses = _context.Statuses.ToList();
            return View(statuses);
        }
    }
}