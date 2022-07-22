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
    public class EmployeeService : BaseService<EmployeeDto, Employee>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(employeeRepository, mapper, unitOfWork)
        {
            _employeeRepository = employeeRepository;
        }

        private readonly IEmployeeRepository _employeeRepository;

        public override async Task<BaseResponse<EmployeeDto>> InsertAsync(EmployeeDto createEmployeeResource)
        {
            try
            {
                // Mapping Resource to Person
                var employee = Mapper.Map<EmployeeDto, Employee>(createEmployeeResource);

                await _employeeRepository.InsertAsync(employee);
                await UnitOfWork.CompleteAsync();

                // Mappping response
                var response = Mapper.Map<Employee, EmployeeDto>(employee);

                return new BaseResponse<EmployeeDto>(response);
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Person_Saving_Error", ex);
            }
        }

        public override async Task<BaseResponse<EmployeeDto>> UpdateAsync(int id, EmployeeDto request)
        {
            try
            {
                // Validate Id is existent
                var employee = await _employeeRepository.GetByIdAsync(id);
                if (employee is null)
                {
                    return new BaseResponse<EmployeeDto>("Country_Id_NoData");
                }

                employee.EmpId = request.EmpId;
                employee.EmpName = request.EmpName;
                employee.DeptId = request.DeptId;

                _employeeRepository.Update(employee);
                await UnitOfWork.CompleteAsync();

                return new BaseResponse<EmployeeDto>(Mapper.Map<Employee, EmployeeDto>(employee));
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Country_Saving_Error", ex);
            }
        }

        public override async Task<BaseResponse<EmployeeDto>> GetByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            // Mapping
            var personResource = Mapper.Map<Employee, EmployeeDto>(employee);

            return new BaseResponse<EmployeeDto>(personResource);
        }
    }
}
