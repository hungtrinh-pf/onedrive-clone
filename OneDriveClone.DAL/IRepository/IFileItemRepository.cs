using OneDriveClone.Core.DTOs;

namespace OneDriveClone.DAL.IRepository
{
    public interface IFileItemRepository
    {
        Task<IEnumerable<FileReadDto>> GetAllAsync();
        Task<FileReadDto> GetByIdAsync(string id);
        Task<int> CreateAsync(FileCreateDto createDto);
        Task<int> UpdateAsync(string id, FileUpdateDto newItem);
        Task<int> DeleteAsync(string id);
    }
}
