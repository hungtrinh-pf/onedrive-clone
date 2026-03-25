using OneDriveClone.Core.DTOs;
using OneDriveClone.Core.Entities;

namespace OneDriveClone.DAL.IRepository
{
    public interface IFolderItemRepository
    {
        Task<IEnumerable<FolderItem>> GetAllAsync();
        Task<FolderItem?> GetByIdAsync(string id);
        Task<int> CreateAsync(FolderItem item);
        Task<int> UpdateAsync(string id, FolderUpdateDto newItem);
        Task<int> DeleteAsync(string id);
    }
}
