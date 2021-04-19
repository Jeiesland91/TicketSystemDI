using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Controllers;
using TicketSystem.Models;

namespace TicketSystemTests
{
    public class StatusControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            // arrange
            var rep = new Mock<IRepository<Status>>();
            var controller = new StatusController(rep.Object);

            // act
            var result = controller.Index();

            // assert
            Assert.IsType<ViewResult>(result);

        }
    }
}