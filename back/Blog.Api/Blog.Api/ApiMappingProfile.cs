using AutoMapper;
using Blog.Api.Models;
using Blog.Api.Models.Responce;
using Blog.Domain.Models;

namespace Blog.Api
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<TestTable, GetTestTableResponse>();
            CreateMap<Post, PostResponse>();
        }
    }
}


