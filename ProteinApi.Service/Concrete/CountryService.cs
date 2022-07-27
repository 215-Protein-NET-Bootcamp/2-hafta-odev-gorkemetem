using AutoMapper;
using ProteinApi.Data;
using ProteinApi.Dto;

namespace ProteinApi.Service
{
    public class CountryService : BaseService<CountryDto, Country>, ICountryService
    {
        public CountryService(ICountryRepository countryRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(countryRepository, mapper, unitOfWork)
        {
        }
    }
}
