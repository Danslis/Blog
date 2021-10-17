using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Blog.Application.Services;
using Blog.Domain;
using Blog.Domain.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Blog.Tests
{
    class BlogServiceTests
    {
        private Mock<IBlogRepository> _testRepositoryMock;
        private BlogService _service;
        private List<Post> _data;

        [SetUp]
        public void SetUp()
        {
            _testRepositoryMock = new Mock<IBlogRepository>();
            _service = new BlogService(_testRepositoryMock.Object);
            _data = new List<Post>
            {
                new Post { Id = 1, Title = "Test1", Text = "Test1 Test1 Test1 Test1 Test1 Test1", Author = "Test@email.com", Date = DateTime.Now},
                new Post { Id = 2, Title = "Test2", Text = "Test2 Test2 Test2 Test2 Test2 Test2", Author = "Test@email.com", Date = DateTime.Now},
                new Post { Id = 3, Title = "Test3", Text = "Test3 Test3 Test3 Test3 Test3 Test3", Author = "Test@email.com", Date = DateTime.Now }
            };
        }
        [Test]
        public async Task GetPostAsync_Should()
        {
            //arrange
            _testRepositoryMock.Setup(x => x.GetPostsAsync())
                .ReturnsAsync(_data).Verifiable();
            //act
            var results = await _service.GetPostsAsync();

            //assert
            _testRepositoryMock.VerifyAll();
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count());
            Assert.AreEqual("Test1", results.Where(x => x.Title == "Test1").Select(x => x.Title).FirstOrDefault());
            Assert.AreEqual("Test2", results.Where(x => x.Title == "Test2").Select(x => x.Title).FirstOrDefault());
            Assert.AreEqual("Test3", results.Where(x => x.Title == "Test3").Select(x => x.Title).FirstOrDefault());

        }

        [Test]
        public async Task GetPostByIdAsync_Should()
        {
            //arrange
            var fixture = new Fixture();
            var id = fixture.Create<long>();

            var post = fixture.Build<Post>()
                .With(x => x.Id, id)
                .Create();
            //act        
            _testRepositoryMock.Setup(x => x.GetPostById(post.Id))
               .ReturnsAsync(post);

            var result = await _service.GetPostById(id);

            _testRepositoryMock.Verify(x => x.GetPostById(id), Times.Once);
            //assert        
            Assert.AreEqual(id, result.Id);
            

        }

        [Test]
        public async Task CreatePostAsync_Should()
        {
            var fixture = new Fixture();

            var addPost = fixture.Build<Post>()
                .Without(x => x.Id)
                .Create();

            _testRepositoryMock.Setup(x => x.CreatePost(addPost))
                .ReturnsAsync(addPost);

            var result = await _service.CreatePost(addPost);

            result.Should().Be(addPost);

            _testRepositoryMock.Verify(x => x.CreatePost(addPost), Times.Once);

        }

        [Test]
        public async Task DeletePostAsync_Should()
        {
            var fixture = new Fixture();
            var id = fixture.Create<long>();

            var deletePost = fixture.Build<Post>()
                .With(x => x.Id, id)
                .Create();

            _testRepositoryMock.Setup(x => x.DeletePost(id))
                .ReturnsAsync(deletePost);

            var result = await _service.DeletePost(id);

            result.Should().Be(deletePost);
            _testRepositoryMock.Verify(x => x.DeletePost(id), Times.Once);
        }
        [Test]
        public async Task UpdatePostAsync_Should()
        {
            var fixture = new Fixture();

            var updatePost = fixture.Build<Post>()
                .Without(x => x.Id)
                .Create();

            _testRepositoryMock.Setup(x => x.UpdatePost(updatePost))
                .ReturnsAsync(updatePost);

            var result = await _service.UpdatePost(updatePost);

            result.Should().Be(updatePost);

            _testRepositoryMock.Verify(x => x.UpdatePost(updatePost), Times.Once);
        }
    }
}