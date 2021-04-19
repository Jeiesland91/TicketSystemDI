using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Controllers;
using TicketSystem.Models;

namespace TicketSystemTests
{
    public class PointControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            // arrange
            var rep = new Mock<IRepository<Point>>();
            var controller = new PointController(rep.Object);

            // act
            var result = controller.Index();

            // assert
            Assert.IsType<ViewResult>(result);

        }
    }
}
