namespace ProteinApi.Data
{
    public class FolderRepository : BaseRepository<Folder>, IFolderRepository
    {
        public FolderRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
