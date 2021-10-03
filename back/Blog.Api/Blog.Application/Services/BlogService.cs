using Blog.Domain;
using Blog.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class BlogService: IBlogService
    {
        private IBlogRepository _repository;

        public BlogService(IBlogRepository repository)
        {
            _repository = repository;
        }

        public Task<Post> CreatePost(Post post)
        {
            throw new System.NotImplementedException();
        }

        public Task<Post> DeletePost(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Post> GetPostById(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetPostsAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<TestTable>> GetTestTablesAsync()
        {
            var testTables = await _repository.GetTestTablesAsync();
            return testTables;
        }

        public Task<Post> UpdatePost(Post post)
        {
            throw new System.NotImplementedException();
        }
    }
}
