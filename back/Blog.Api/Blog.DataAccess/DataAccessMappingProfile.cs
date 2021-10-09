using AutoMapper;
using Blog.DataAccess.Entities;
using Blog.Domain.Models;

namespace Blog.DataAccess
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<TestTable, TestTableEntity>()
                .ReverseMap();
            CreateMap<Post, PostEntity>()
                .ReverseMap();
        }
    }
}
