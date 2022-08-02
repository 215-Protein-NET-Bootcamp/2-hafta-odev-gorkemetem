using AutoMapper;
using ProteinApi.Base;
using ProteinApi.Data;
using ProteinApi.Dto;
using System.Threading.Tasks;

namespace ProteinApi.Service
{
    public class EmployeeService : BaseService<EmployeeDto, Employee>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(employeeRepository, mapper, unitOfWork)
        {
            
        }

  
    }
}
