using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TicketSystem.Controllers;
using TicketSystem.Models;

namespace TicketSystemTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            // arrange
            var unit = new Mock<ITicketUnitOfWork>();
            var tickets = new Mock<IRepository<Ticket>>();
            unit.Setup(r => r.Tickets).Returns(tickets.Object);

            var http = new Mock<IHttpContextAccessor>();

            var controller = new HomeController(unit.Object, http.Object);

            // act
            var result = controller.Index(0);

            // assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
