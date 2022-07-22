using AutoMapper;
using ProteinApi.Data;
using ProteinApi.Dto;

namespace ProteinApi.Service.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Folder, FolderDto>().ReverseMap();
        }

    }
}
