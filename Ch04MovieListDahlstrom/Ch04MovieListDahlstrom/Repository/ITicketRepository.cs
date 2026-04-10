using Ch04MovieListDahlstrom.Models;

namespace Ch04MovieListDahlstrom.Repository
{
    public interface ITicketRepository
    {
        List<Ticket> GetAllTickets();
        Ticket Find(int id);
        void InsertTicket(Ticket ticket);
        void UpdateTicket(Ticket ticket);
        void DeleteTicket(Ticket ticket);
        void Save();
    }
}