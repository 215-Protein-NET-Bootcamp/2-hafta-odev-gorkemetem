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
    public class FolderService : BaseService<FolderDto, Folder>, IFolderService
    {
        public FolderService(IFolderRepository folderRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(folderRepository, mapper, unitOfWork)
        {
            
        }

    }
}
