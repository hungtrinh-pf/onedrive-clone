using Microsoft.EntityFrameworkCore;
using OneDriveClone.Core.DTOs;
using OneDriveClone.Core.Entities;
using OneDriveClone.DAL.IRepository;

namespace OneDriveClone.DAL.Repository
{
    public class FolderItemRepository(AppDbContext context) : IFolderItemRepository
    {
        private readonly AppDbContext _context = context;

        private async Task<List<FolderItem>> GetDescendants(string id)
        {
            var subfolders = await  _context.FolderItems.Where(f => f.ParentId == id).ToListAsync();

            var descendants = new List<FolderItem>();
            foreach (var subfolder in subfolders)
            {
                descendants.Add(subfolder);
                descendants.AddRange(await GetDescendants(subfolder.Id));
            }

            return descendants;
        }

        public async Task<int> CreateAsync(FolderItem item)
        {
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

        public async Task<IEnumerable<FolderItem>> GetAllAsync()
        {
            return _context.FolderItems;
        }

        public async Task<FolderItem?> GetByIdAsync(string id)
        {
            return await _context.FolderItems.SingleOrDefaultAsync(item => item.Id == id);
        }

        public async Task<IEnumerable<FolderItem>> GetByIdAsync(params string[] ids)
        {
            return _context.FolderItems.Where(item => ids.Contains(item.Id));
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
