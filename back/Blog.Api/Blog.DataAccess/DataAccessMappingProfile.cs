using AutoMapper;
using Blog.DataAccess.Entities;
using Blog.Domain.Dto;


namespace Blog.DataAccess
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<TestTableDto, TestTableEntity>()
                .ReverseMap();
        }
    }
}
