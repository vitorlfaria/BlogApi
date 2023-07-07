using Application.DataTransferObjects;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper;

public class ProfileConfigurationMap : Profile
{
    public ProfileConfigurationMap()
    {
        CreateMap<Tag, TagDto>().ReverseMap();
        CreateMap<BlogPost, BlogPostDto>().ReverseMap();
    }
}