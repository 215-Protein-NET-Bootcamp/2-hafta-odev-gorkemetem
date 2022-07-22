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
    public class DepartmentService : BaseService<DepartmentDto, Department>, IDepartmentService
    {
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(baseRepository, mapper, unitOfWork)
        {
            _departmentRepository = departmentRepository;
        }

        private readonly IDepartmentRepository _departmentRepository;

        public override async Task<BaseResponse<DepartmentDto>> InsertAsync(DepartmentDto createCountryResource)
        {
            try
            {
                // Mapping Resource to Person
                var department = Mapper.Map<CountryDto, Country>(createDepartmentResource);

                await _departmentRepository.InsertAsync(department);
                await UnitOfWork.CompleteAsync();

                // Mappping response
                var response = Mapper.Map<Department, DepartmentDto>(department);

                return new BaseResponse<DepartmentDto>(response);
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Department_Saving_Error", ex);
            }
        }

        public override async Task<BaseResponse<CountryDto>> UpdateAsync(int id, CountryDto request)
        {
            try
            {
                // Validate Id is existent
                var country = await _departmentRepository.GetByIdAsync(id);
                if (country is null)
                {
                    return new BaseResponse<CountryDto>("Country_Id_NoData");
                }

                country.CountryId = request.CountryId;
                country.CountryName = request.CountryName;
                country.Continent = request.Continent;
                country.Currency = request.Currency;

                _departmentRepository.Update(country);
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
