using System;
using AutoMapper;
using Blog.DataAccess.Context;
using Blog.Domain;
using Blog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.DataAccess.Entities;

namespace Blog.DataAccess.Repositories
{
    public class BlogRepository: IBlogRepository
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;

        public BlogRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TestTable>> GetTestTablesAsync()
        {
            var testTables = await _context.TestTable.ToListAsync();
            return _mapper.Map<IEnumerable<TestTable>>(testTables);
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            try
            {
                var posts = await _context.Posts.ToListAsync();
                return _mapper.Map<IEnumerable<Post>>(posts);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Post> GetPostById(long id)
        {
            try
            {
                var post = await _context.Posts.FirstOrDefaultAsync(x=>x.Id == id);
                return _mapper.Map<Post>(post);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Post> CreatePost(Post post)
        {
            try
            {
                var newPost = await _context.Posts.AddAsync(_mapper.Map<PostEntity>(post));
                await _context.SaveChangesAsync();
                var result = _mapper.Map<Post>(newPost.Entity);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Post> UpdatePost(Post post)
        {
            try
            {
                var entity = await _context.Posts.FirstOrDefaultAsync(x => x.Id == post.Id);
                if (entity != null)
                {
                    entity.Title = post.Title;
                    entity.Text = post.Text;
                    entity.Author = post.Author;
                    entity.Date = DateTime.Now;
                    _context.Posts.Update(entity);
                    await _context.SaveChangesAsync();
                }
                return _mapper.Map<Post>(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Post> DeletePost(long id)
        {
            try
            {
                var entity = await _context.Posts.FirstOrDefaultAsync(x => x.Id == id);
                if (entity != null)
                {
                    _context.Posts.Remove(entity); 
                    await _context.SaveChangesAsync();
                }
                return _mapper.Map<Post>(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
