using AutoMapper;
using Blog.Api.Models;
using Blog.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITestService _service;


        public TestController(IMapper mapper, ITestService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<GetTestTableResponse>> Get()
        {
            var data = await _service.GetTestTablesAsync();
            var result = _mapper.Map<IEnumerable<GetTestTableResponse>>(data);
            return result;
        }
    }
}
