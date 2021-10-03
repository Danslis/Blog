using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Api.Models.Request;
using Blog.Api.Models.Responce;
using Blog.Domain;
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

        [HttpGet]
        public async Task<IEnumerable<PostResponse>> Get()
        {
            var results = await _service.GetPostsAsync();
            return null;
        }

        [HttpGet("{id}")]
        public PostResponse Get(int id)
        {
            return null;
        }

        [HttpPost]
        public IActionResult Post(PostRequest product)
        {
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(PostRequest product)
        {
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return null;
        }
    }
}
