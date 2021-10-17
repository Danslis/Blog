using Blog.Domain;
using Blog.Domain.Models;
using System;
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

        public async Task<Post> CreatePost(Post post)
        {
            try 
            { 
                var result = await _repository.CreatePost(post);
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        public async Task<Post> DeletePost(long id)
        {
            try
            {
                var result = await _repository.DeletePost(id);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Post> GetPostById(long id)
        {
            try
            {
                var result = await _repository.GetPostById(id);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            try
            {
                var result = await _repository.GetPostsAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<TestTable>> GetTestTablesAsync()
        {
            var testTables = await _repository.GetTestTablesAsync();
            return testTables;
        }

        public async Task<Post> UpdatePost(Post post)
        {
            try
            {
                var result = await _repository.UpdatePost(post);
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
