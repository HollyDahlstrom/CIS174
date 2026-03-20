using Microsoft.EntityFrameworkCore;

namespace Ch04MovieListDahlstrom.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options)
            : base(options) { }

        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "To Do", Name = "To Do" },
                new Status { StatusId = "In Progress", Name = "In Progress" },
                new Status { StatusId = "QA", Name = "Quality Assurance" },
                new Status { StatusId = "Done", Name = "Done" }
            );

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { TicketId = 1, Name = "Setup Project", Description = "Create solution and project files", SprintNumber = 1, PointValue = 3, StatusId = "To Do" },
                new Ticket { TicketId = 2, Name = "Create Models", Description = "Add Ticket model", SprintNumber = 1, PointValue = 5, StatusId = "In Progress" },
                new Ticket { TicketId = 3, Name = "Build Views", Description = "Implement Index view for tickets", SprintNumber = 2, PointValue = 8, StatusId = "QA" }
            );
        }
    }
}