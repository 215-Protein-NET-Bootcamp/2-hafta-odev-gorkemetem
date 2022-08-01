using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ProteinApi.Data
{
    public class FolderRepository : BaseRepository<Folder>, IFolderRepository
    {
        public FolderRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Folder> GetByIdAsync(int id)
        {
            return await Context.folder.AsSplitQuery().SingleOrDefaultAsync(x => x.FolderId == id);
        }
    }
}
