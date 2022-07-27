using AutoMapper;
using ProteinApi.Data;
using ProteinApi.Dto;

namespace ProteinApi.Service
{
    public class FolderService : BaseService<FolderDto, Folder>, IFolderService
    {
        public FolderService(IFolderRepository folderRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(folderRepository, mapper, unitOfWork)
        {
            
        }

    }
}
