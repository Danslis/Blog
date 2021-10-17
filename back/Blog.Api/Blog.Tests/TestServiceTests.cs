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
        private Mock<ITestRepository> _testRepositoryMock;
        private TestService _service;
        private TestTable[] _data;

        [SetUp]
        public void SetUp()
        {
            _testRepositoryMock = new Mock<ITestRepository>();
            _service = new TestService(_testRepositoryMock.Object);
            _data = new[]
            {
                new TestTable { Id = 1, Name = "Test1" },
                new TestTable { Id = 2, Name = "Test2" },
                new TestTable { Id = 3, Name = "Test3" }
            };
        }
        [Test]
        public async Task GetTestTablesAsync_Should()
        {
            //Arrange
            _testRepositoryMock.Setup(x => x.GetTestTablesAsync())
                .ReturnsAsync(_data).Verifiable();
            //Act
            var results = await _service.GetTestTablesAsync();

            //Assert
            _testRepositoryMock.VerifyAll();
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count());
            Assert.AreEqual("Test1", results.Where(x=>x.Name=="Test1").Select(x=>x.Name).FirstOrDefault());
            Assert.AreEqual("Test2", results.Where(x => x.Name == "Test2").Select(x => x.Name).FirstOrDefault());
            Assert.AreEqual("Test3", results.Where(x => x.Name == "Test3").Select(x => x.Name).FirstOrDefault());

        }
    }
}
