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
            _folderRepository = folderRepository;
        }

        private readonly IFolderRepository _folderRepository;

        public override async Task<BaseResponse<FolderDto>> InsertAsync(FolderDto createFolderResource)
        {
            try
            {
                // Mapping Resource to Person
                var folder = Mapper.Map<FolderDto, Folder>(createFolderResource);

                await _folderRepository.InsertAsync(folder);
                await UnitOfWork.CompleteAsync();

                // Mappping response
                var response = Mapper.Map<Folder, FolderDto>(folder);

                return new BaseResponse<FolderDto>(response);
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Folder_Saving_Error", ex);
            }
        }

        public override async Task<BaseResponse<FolderDto>> UpdateAsync(int id, FolderDto request)
        {
            try
            {
                // Validate Id is existent
                var folder = await _folderRepository.GetByIdAsync(id);
                if (folder is null)
                {
                    return new BaseResponse<FolderDto>("Folder_Id_NoData");
                }

                folder.FolderId = request.FolderId;
                folder.EmpId = request.EmpId;
                folder.AccessType = request.AccessType;

                _folderRepository.Update(folder);
                await UnitOfWork.CompleteAsync();

                return new BaseResponse<FolderDto>(Mapper.Map<Folder, FolderDto>(folder));
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Folder_Saving_Error", ex);
            }
        }

        public override async Task<BaseResponse<FolderDto>> GetByIdAsync(int id)
        {
            var folder = await _folderRepository.GetByIdAsync(id);

            // Mapping
            var folderResource = Mapper.Map<Folder, FolderDto>(folder);

            return new BaseResponse<FolderDto>(folderResource);
        }
    }
}
