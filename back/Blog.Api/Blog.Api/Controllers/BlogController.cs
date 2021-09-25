using AutoMapper;
using Blog.Api.Models;
using Blog.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBlogService _service;
        

        public BlogController(IMapper mapper, IBlogService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<GetTestTableResponse>> Get()
        {
            var result = await _service.GetTestTablesAsync();
            return _mapper.Map<IEnumerable<GetTestTableResponse>>(result);
        }
    }
}
