using AutoMapper;
using ProteinApi.Data;
using ProteinApi.Dto;

namespace ProteinApi.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Author, AuthorDto>().ReverseMap();
        }

    }
}
