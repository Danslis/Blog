using System.Linq;
using System.Threading.Tasks;
using Blog.Application.Services;
using Blog.Domain;
using Blog.Domain.Models;
using Moq;
using NUnit.Framework;

namespace Blog.Tests
{
    class TestServiceTests
    {
        [Test]
        public async Task GetTestTablesAsync_Should()
        {
            var testRepositoryMock = new Mock<ITestRepository>();
            //Arrange
            var data = new[]
            {
                new TestTable { Id = 1, Name = "Test1" },
                new TestTable { Id = 2, Name = "Test2" },
                new TestTable { Id = 3, Name = "Test3" }
            };
            testRepositoryMock.Setup(x => x.GetTestTablesAsync())
                .ReturnsAsync(data).Verifiable();
            //Act
            var service = new TestService(testRepositoryMock.Object);
            var results = await service.GetTestTablesAsync();

            //Assert
            testRepositoryMock.VerifyAll();
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count());
            Assert.AreEqual("Test1", results.Where(x=>x.Name=="Test1").Select(x=>x.Name).FirstOrDefault());
            Assert.AreEqual("Test2", results.Where(x => x.Name == "Test2").Select(x => x.Name).FirstOrDefault());
            Assert.AreEqual("Test3", results.Where(x => x.Name == "Test3").Select(x => x.Name).FirstOrDefault());

        }
    }
}
