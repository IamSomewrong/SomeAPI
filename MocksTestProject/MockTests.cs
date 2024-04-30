using Microsoft.Extensions.Logging;
using Moq;
using SomeAPI.Controllers;

namespace MocksTestProject
{
    public class MockTests
    {
        [Fact]
        public void TestMoq()
        {
            var loggerMock = new Mock<ILogger<PersonController>>();

            var controller = new PersonController(loggerMock.Object);

            var actual = controller.Get();

            loggerMock.Verify(x => x.IsEnabled(LogLevel.Information), Times.Exactly(2));
        }

        [Fact]
        public void TestMyMock()
        {
            var loggerMock = new MyMock();

            var controller = new PersonController(loggerMock);

            var actual = controller.Get();

            Assert.Equal(2, loggerMock.LogCallsCount);
        }
    }
}