using System;
using AutoMapper;
using Blog.Api.Models;
using Blog.Domain.Dto;

namespace Blog.Api
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {         
           CreateMap<GetTestTableResponse, TestTableDto>().ReverseMap(); ;           
        }
    }
}



