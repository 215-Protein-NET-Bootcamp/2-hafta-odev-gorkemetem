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
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(departmentRepository, mapper, unitOfWork)
        {
            _departmentRepository = departmentRepository;
        }

        private readonly IDepartmentRepository _departmentRepository;

        public override async Task<BaseResponse<DepartmentDto>> InsertAsync(DepartmentDto createDepartmentResource)
        {
            try
            {
                // Mapping Resource to Person
                var department = Mapper.Map<DepartmentDto, Department>(createDepartmentResource);

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

        public override async Task<BaseResponse<DepartmentDto>> UpdateAsync(int id, DepartmentDto request)
        {
            try
            {
                // Validate Id is existent
                var department = await _departmentRepository.GetByIdAsync(id);
                if (department is null)
                {
                    return new BaseResponse<DepartmentDto>("Department_Id_NoData");
                }

                department.DepartmentId = request.DepartmentId;
                department.DeptName = request.DeptName;
                department.CountryId = request.CountryId;

                _departmentRepository.Update(department);
                await UnitOfWork.CompleteAsync();

                return new BaseResponse<DepartmentDto>(Mapper.Map<Department, DepartmentDto>(department));
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Country_Saving_Error", ex);
            }
        }

        public override async Task<BaseResponse<DepartmentDto>> GetByIdAsync(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);

            // Mapping
            var departmentResource = Mapper.Map<Department, DepartmentDto>(department);

            return new BaseResponse<DepartmentDto>(departmentResource);
        }
    }
}
