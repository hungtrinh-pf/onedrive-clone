using Microsoft.EntityFrameworkCore;
using OneDriveClone.Core.DTOs.Folder;
using OneDriveClone.Core.Entities;
using OneDriveClone.Core.Mappers;
using OneDriveClone.DAL.IRepository;

namespace OneDriveClone.DAL.Repository
{
    internal class FolderItemRepository(AppDbContext context) : IFolderItemRepository
    {
        private readonly AppDbContext _context = context;

        private async Task<IList<FolderItem>> GetDescendants(string id)
        {
            var subfolders = await _context.FolderItems.Where(f => f.ParentId == id).ToListAsync();

            var descendants = new List<FolderItem>();
            foreach (var subfolder in subfolders)
            {
                descendants.Add(subfolder);
                descendants.AddRange(await GetDescendants(subfolder.Id));
            }

            return descendants;
        }

        public async Task<int> CreateAsync(FolderCreateDto createDto)
        {
            var item = FolderMapper.ToFolder(createDto);
            await _context.FolderItems.AddAsync(item);
            return _context.SaveChanges();
        }

        public async Task<int> DeleteAsync(string id)
        {
            var folder = await _context.FolderItems.FirstOrDefaultAsync(f => f.Id == id);
            if (folder is null)
            {
                return -1;
            }

            var toDelete = await GetDescendants(id);
            toDelete.Add(folder);

            _context.FolderItems.RemoveRange(toDelete);
            return _context.SaveChanges();
        }

        public async Task<IEnumerable<FolderReadDto>> GetAllAsync()
        {
            return _context.FolderItems.Select(folder => FolderMapper.ToReadDto(folder));
        }

        public async Task<FolderReadDto> GetByIdAsync(string id)
        {
            var folder = await _context.FolderItems
                .Include(item => item.Subfolders)
                .Include(item => item.Files)
                .FirstOrDefaultAsync(item => item.Id == id);

            return folder is not null ? FolderMapper.ToReadDto(folder) : new FolderReadDto();
        }

        public async Task<int> UpdateAsync(string id, FolderUpdateDto newItem)
        {
            var folder = await _context.FolderItems.FirstOrDefaultAsync(item => item.Id == id);
            if (folder is not null)
            {
                folder.Name = newItem.Name;
                folder.ModifiedAt = DateTime.Now;
                folder.ModifiedBy = newItem.ModifiedBy;

                return _context.SaveChanges();
            }
            return -1;
        }
    }
}
