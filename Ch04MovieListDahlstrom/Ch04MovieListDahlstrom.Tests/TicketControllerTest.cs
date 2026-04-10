using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;
using Ch04MovieListDahlstrom.Controllers;
using Ch04MovieListDahlstrom.Models;
using Ch04MovieListDahlstrom.Repository;

namespace Ch04MovieListDahlstrom.Tests
{
    public class TicketControllerTest
    {
        [Fact]
        public void Index_ReturnsViewResult()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase("TestDB")
                .Options;

            var context = new TicketContext(options);

            // mock repository 
            var mockRepo = new Mock<ITicketRepository>();

            // return fake data from repository
            mockRepo.Setup(r => r.GetAllTickets())
                .Returns(new List<Ticket>
                {
                    new Ticket { TicketId = 1, Name = "Test", StatusId = "To Do" }
                });

            var controller = new TicketController(mockRepo.Object, context);

            // Act
            var result = controller.Index(null);

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Add_ReturnsView()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase("AddTestDB")
                .Options;

            var context = new TicketContext(options);

            var mockRepo = new Mock<ITicketRepository>();

            var controller = new TicketController(mockRepo.Object, context);

            // Act
            var result = controller.Add();

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}