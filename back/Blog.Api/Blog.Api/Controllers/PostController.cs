using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Api.Models.Request;
using Blog.Api.Models.Responce;
using Blog.Domain;
using Blog.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBlogService _service;


        public PostController(IMapper mapper, IBlogService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("get-posts")]
        public async Task<IEnumerable<PostResponse>> Get()
        {
            try
            {
                var data = await _service.GetPostsAsync();
                var results = _mapper.Map<IEnumerable<PostResponse>>(data);
                return results;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpGet("get-posts-by-id/{id}")]
        public async Task<PostResponse> Get(int id)
        {
            var data = await _service.GetPostById(id);
            var result = _mapper.Map<PostResponse>(data);
            return result;
        }

        [HttpPost]
        public async Task<PostResponse> Post(PostRequest post)
        {
            try
            {
                var results = await _service.CreatePost(new Post()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Text = post.Text,
                    Author = post.Author,
                    Date = post.Date,
                });
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<PostResponse> Put(PostRequest post)
        {
            try
            {
                var results = await _service.UpdatePost(new Post()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Text = post.Text,
                    Author = post.Author,
                    Date = post.Date,
                });
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<PostResponse> Delete(int id)
        {
            try
            {
                var results = await _service.DeletePost(id);                
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
