using OneDriveClone.Core.DTOs.Folder;

namespace OneDriveClone.DAL.IRepository
{
    public interface IFolderItemRepository
    {
        Task<IEnumerable<FolderReadDto>> GetAllAsync();
        Task<FolderReadDto> GetByIdAsync(string id);
        Task<int> CreateAsync(FolderCreateDto item);
        Task<int> UpdateAsync(string id, FolderUpdateDto newItem);
        Task<int> DeleteAsync(string id);
    }
}
