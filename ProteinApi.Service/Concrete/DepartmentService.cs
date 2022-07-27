using AutoMapper;
using ProteinApi.Data;
using ProteinApi.Dto;

namespace ProteinApi.Service
{
    public class DepartmentService : BaseService<DepartmentDto, Department>, IDepartmentService
    {
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(departmentRepository, mapper, unitOfWork)
        {
            
        }

      
    }
}
