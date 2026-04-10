using Ch04MovieListDahlstrom.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Xunit;

namespace Ch04MovieListDahlstrom.Tests
{
    public class TicketRepositoryInMemoryTest
    {
        private DbContextOptions<TicketContext> options;

        public TicketRepositoryInMemoryTest()
        {
            options = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase("TicketDB")
                .ConfigureWarnings(x =>
                    x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
        }

        [Fact] 
        public void GetAllTickets_HappyPath()
        {
            // Arrange
            var context = new TicketContext(options);

            context.Tickets.Add(new Ticket
            {
                TicketId = 1,
                Name = "Test1",
                Description = "Desc1",
                SprintNumber = 1,
                PointValue = 3,
                StatusId = "To Do"
            });

            context.Tickets.Add(new Ticket
            {
                TicketId = 2,
                Name = "Test2",
                Description = "Desc2",
                SprintNumber = 1,
                PointValue = 5,
                StatusId = "Done"
            });

            context.SaveChanges();

            var repo = new TicketRepository(context);

            // Act
            var result = repo.GetAllTickets();

            // Assert
            Assert.Equal(2, result.Count); 
        }

        [Fact]
        public void GetDoneTickets_HappyPath()
        {
            var context = new TicketContext(options);

            context.Tickets.Add(new Ticket
            {
                TicketId = 3,
                Name = "Test3",
                Description = "Desc3",
                SprintNumber = 2,
                PointValue = 8,
                StatusId = "Done"
            });

            context.SaveChanges();

            var repo = new TicketRepository(context);

            var result = repo.GetAllTickets().Where(t => t.StatusId == "Done");

            Assert.All(result, t => Assert.Equal("Done", t.StatusId));
        }
    }
}