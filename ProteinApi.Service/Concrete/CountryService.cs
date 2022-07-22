using AutoMapper;
using ProteinApi.Base;
using ProteinApi.Data;
using ProteinApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProteinApi.Service
{
    public class CountryService : BaseService<CountryDto, Country>, ICountryService
    {
        public CountryService(ICountryRepository countryRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(countryRepository, mapper, unitOfWork)
        {
            _countryRepository = countryRepository;
        }

        private readonly ICountryRepository _countryRepository;

        public override async Task<BaseResponse<CountryDto>> InsertAsync(CountryDto createCountryResource)
        {
            try
            {
                // Mapping Resource to Person
                var country = Mapper.Map<CountryDto, Country>(createCountryResource);

                await _countryRepository.InsertAsync(country);
                await UnitOfWork.CompleteAsync();

                // Mappping response
                var response = Mapper.Map<Country, CountryDto>(country);

                return new BaseResponse<CountryDto>(response);
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Person_Saving_Error", ex);
            }
        }

        public override async Task<BaseResponse<CountryDto>> UpdateAsync(int id, CountryDto request)
        {
            try
            {
                // Validate Id is existent
                var country = await _countryRepository.GetByIdAsync(id);
                if (country is null)
                {
                    return new BaseResponse<CountryDto>("Country_Id_NoData");
                }

                country.CountryId = request.CountryId;
                country.CountryName = request.CountryName;
                country.Continent = request.Continent;
                country.Currency = request.Currency;

                _countryRepository.Update(country);
                await UnitOfWork.CompleteAsync();

                return new BaseResponse<CountryDto>(Mapper.Map<Country, CountryDto>(country));
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Country_Saving_Error", ex);
            }
        }

        public override async Task<BaseResponse<CountryDto>> GetByIdAsync(int id)
        {
            var person = await _countryRepository.GetByIdAsync(id);

            // Mapping
            var personResource = Mapper.Map<Country, CountryDto>(person);

            return new BaseResponse<CountryDto>(personResource);
        }

    }
}
