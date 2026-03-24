using OneDriveClone.Core.DTOs;
using OneDriveClone.Core.Response;

namespace OneDriveClone.BLL.IService
{
    public interface IFolderItemService
    {
        Task<ResponseObject<IEnumerable<FolderReadDto>>> GetAllFoldersAsync();
        Task<ResponseObject<FolderReadDto>> GetFolderByIdAsync(string id);
        Task<ResponseObject<int>> CreateFolderAsync(FolderCreateDto item);
        Task<ResponseObject<int>> UpdateFolderAsync(string id, FolderUpdateDto newItem);
        Task<ResponseObject<int>> DeleteFolderAsync(string id);
    }
}
