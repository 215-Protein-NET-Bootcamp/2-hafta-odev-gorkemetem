using AutoMapper;
using ProteinApi.Base;
using ProteinApi.Data;
using ProteinApi.Dto;
using System;
using System.Threading.Tasks;


namespace ProteinApi.Service
{
    public class AuthorService : BaseService<AuthorDto, Author>, IAuthorService
    {
        public AuthorService(IAuthorRepository AuthorRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(AuthorRepository, mapper, unitOfWork)
        {
            this.AuthorRepository = AuthorRepository;
        }

        private readonly IAuthorRepository AuthorRepository;


        public override async Task<BaseResponse<AuthorDto>> InsertAsync(AuthorDto createAuthorResource)
        {
            try
            {
                // Mapping Resource to Author
                var Author = Mapper.Map<AuthorDto, Author>(createAuthorResource);

                await AuthorRepository.InsertAsync(Author);
                await UnitOfWork.CompleteAsync();

                // Mappping response
                var response = Mapper.Map<Author, AuthorDto>(Author);

                return new BaseResponse<AuthorDto>(response);
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Author_Saving_Error", ex);
            }
        }

        public override async Task<BaseResponse<AuthorDto>> UpdateAsync(int id, AuthorDto request)
        {
            try
            {
                // Validate Id is existent
                var Author = await AuthorRepository.GetByIdAsync(id);
                if (Author is null)
                {
                    return new BaseResponse<AuthorDto>("Author_Id_NoData");
                }

                Author.FirstName = request.FirstName;
                Author.LastName = request.LastName;
                Author.Email = request.Email;

                AuthorRepository.Update(Author);
                await UnitOfWork.CompleteAsync();

                return new BaseResponse<AuthorDto>(Mapper.Map<Author, AuthorDto>(Author));
            }
            catch (Exception ex)
            {
                throw new MessageResultException("Author_Saving_Error", ex);
            }
        }

        public override async Task<BaseResponse<AuthorDto>> GetByIdAsync(int id)
        {
            var Author = await AuthorRepository.GetByIdAsync(id);

            // Mapping
            var AuthorResource = Mapper.Map<Author, AuthorDto>(Author);

            return new BaseResponse<AuthorDto>(AuthorResource);
        }

    }
}
