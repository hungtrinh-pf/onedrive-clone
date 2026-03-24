using OneDriveClone.Core.DTOs;
using OneDriveClone.Core.Entities;

namespace OneDriveClone.DAL.IRepository
{
    public interface IFileItemRepository
    {
        Task<IEnumerable<FileItem>> GetAllAsync();
        Task<FileItem?> GetByIdAsync(string id);
        Task<int> CreateAsync(FileItem item);
        Task<int> UpdateAsync(string id, FileUpdateDto newItem);
        Task<int> DeleteAsync(string id);
    }
}
