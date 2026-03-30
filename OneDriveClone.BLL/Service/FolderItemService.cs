using OneDriveClone.BLL.IService;
using OneDriveClone.Core.DTOs.Folder;
using OneDriveClone.Core.Response;
using OneDriveClone.DAL.IRepository;

namespace OneDriveClone.BLL.Service
{
    internal class FolderItemService(IFolderItemRepository folderItemRepository) : IFolderItemService
    {
        private readonly IFolderItemRepository _folderItemRepository = folderItemRepository;

        public async Task<ResponseObject<int>> CreateFolderAsync(FolderCreateDto item)
        {
            if (item.ParentId is not null)
            {
                var parentFolder = await _folderItemRepository.GetByIdAsync(item.ParentId);
                if (parentFolder.Subfolders.Any(folder => folder.Name == item.Name))
                {
                    return Result<int>.BadRequest($"A folder with name '{item.Name}' already exists.");
                }
            }

            int createdCount = await _folderItemRepository.CreateAsync(item);
            return Result<int>.Created($"{createdCount} folder(s) created", createdCount);
        }

        public async Task<ResponseObject<int>> DeleteFolderAsync(string id)
        {
            int deletedCount = await _folderItemRepository.DeleteAsync(id);
            if (deletedCount == -1)
            {
                return Result<int>.NotFound($"Folder with ID {id} not found");
            }
            return Result<int>.NoContent($"{deletedCount} folder(s) deleted");
        }

        public async Task<ResponseObject<IEnumerable<FolderReadDto>>> GetAllFoldersAsync()
        {
            var folders = await _folderItemRepository.GetAllAsync();
            return Result<IEnumerable<FolderReadDto>>.Ok($"{folders.Count()} folder(s) retrieved", folders);
        }

        public async Task<ResponseObject<FolderReadDto>> GetFolderByIdAsync(string id)
        {
            var folder = await _folderItemRepository.GetByIdAsync(id);
            if (folder.Id == string.Empty)
            {
                return Result<FolderReadDto>.NotFound($"Folder with ID {id} not found");
            }
            return Result<FolderReadDto>.Ok("Folder retrieved", folder);
        }

        public async Task<ResponseObject<int>> UpdateFolderAsync(string id, FolderUpdateDto newItem)
        {
            int updatedCount = await _folderItemRepository.UpdateAsync(id, newItem);
            if (updatedCount == -1)
            {
                return Result<int>.NotFound($"Folder with ID {id} not found");
            }
            return Result<int>.NoContent($"{updatedCount} folder(s) updated");
        }
    }
}
