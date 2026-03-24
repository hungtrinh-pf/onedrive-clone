using OneDriveClone.Core.DTOs;
using OneDriveClone.Core.Response;

namespace OneDriveClone.BLL.IService
{
    public interface IFileItemService
    {
        Task<ResponseObject<IEnumerable<FileReadDto>>> GetAllFilesAsync();
        Task<FileReadDto> GetFileAsync(string id);
        Task<ResponseObject<int>> CreateFileAsync(FileCreateDto item);
        Task<ResponseObject<int>> UpdateFileAsync(string id, FileUpdateDto newItem);
        Task<ResponseObject<int>> DeleteFileAsync(string id);
    }
}
