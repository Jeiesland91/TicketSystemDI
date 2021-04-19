using Microsoft.AspNetCore.Http;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Controllers;
using TicketSystem.Models;

namespace TicketSystemTests
{
    public class TicketControllerTests
    {
        [Fact]
        public void IndexActionMethod_ReturnsAViewResult()
        {
            // arrange
            
            var rep = new Mock<ITicketUnitOfWork>();
            var ctx = new Mock<IHttpContextAccessor>();

            var controller = new TicketController(rep.Object, ctx.Object);

            // act
            var result = controller.Index();

            // assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
