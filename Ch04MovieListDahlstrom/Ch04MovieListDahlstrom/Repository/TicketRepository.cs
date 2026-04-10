using Ch04MovieListDahlstrom.Models;

namespace Ch04MovieListDahlstrom.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private TicketContext context;

        public TicketRepository(TicketContext cntx)
        {
            context = cntx;
        }

        public List<Ticket> GetAllTickets()
        {
            return context.Tickets.ToList();
        }

        public Ticket Find(int id)
        {
            return context.Tickets.Find(id);
        }

        public void InsertTicket(Ticket ticket)
        {
            context.Tickets.Add(ticket);
        }

        public void UpdateTicket(Ticket ticket)
        {
            context.Tickets.Update(ticket);
        }

        public void DeleteTicket(Ticket ticket)
        {
            context.Tickets.Remove(ticket);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}