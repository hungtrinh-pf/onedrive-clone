using Microsoft.EntityFrameworkCore;
using OneDriveClone.Core.DTOs;
using OneDriveClone.Core.Entities;
using OneDriveClone.DAL.IRepository;

namespace OneDriveClone.DAL.Repository
{
    public class FileItemRepository(AppDbContext context) : IFileItemRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<int> CreateAsync(FileItem item)
        {
            await _context.FileItems.AddAsync(item);
            return _context.SaveChanges();
        }

        public async Task<int> DeleteAsync(string id)
        {
            var file = await _context.FileItems.SingleOrDefaultAsync(item => item.Id == id);
            if (file is not null)
            {
                _context.FileItems.Remove(file);
                return _context.SaveChanges();
            }
            return -1;
        }

        public async Task<IEnumerable<FileItem>> GetAllAsync()
        {
            return [.. _context.FileItems];
        }

        public async Task<FileItem?> GetByIdAsync(string id)
        {
            return await _context.FileItems.SingleOrDefaultAsync(item => item.Id == id);
        }

        public async Task<int> UpdateAsync(string id, FileUpdateDto newItem)
        {
            var file = await _context.FileItems.FirstOrDefaultAsync(item => item.Id == id);
            if (file is not null)
            {
                file.Name = newItem.Name;
                file.ModifiedAt = DateTime.Now;
                file.ModifiedBy = newItem.ModifiedBy;

                return _context.SaveChanges();
            }
            return -1;
        }
    }
}
