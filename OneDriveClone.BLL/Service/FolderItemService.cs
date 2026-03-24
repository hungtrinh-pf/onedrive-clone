using OneDriveClone.BLL.IService;
using OneDriveClone.Core.DTOs;
using OneDriveClone.Core.Entities;
using OneDriveClone.Core.Response;
using OneDriveClone.DAL.IRepository;

namespace OneDriveClone.BLL.Service
{
    public class FolderItemService(IFolderItemRepository folderItemRepository) : IFolderItemService
    {
        private readonly IFolderItemRepository _folderItemRepository = folderItemRepository;

        public async Task<ResponseObject<int>> CreateFolderAsync(FolderCreateDto item)
        {
            if (item.ParentId is not null)
            {
                var parentFolder = await _folderItemRepository.GetByIdAsync(item.ParentId);
                if (parentFolder is not null)
                {
                    var allFolders = await _folderItemRepository.GetAllAsync();
                    var subfolders = allFolders.Where(item => item.ParentId == parentFolder.Id);

                    if (subfolders.Any(folder => folder.Name == item.Name))
                    {
                        return Result<int>.BadRequest($"A folder with name '{item.Name}' already exists.");
                    }
                }
            }

            var newFolder = new FolderItem
            {
                Id = item.ParentId is not null ? $"{Guid.NewGuid()}" : "root",
                Name = item.Name,
                ParentId = item.ParentId,
                CreatedAt = DateTime.Now,
                CreatedBy = item.CreatedBy,
                ModifiedAt = DateTime.Now,
                ModifiedBy = item.ModifiedBy,
            };

            int createdCount = await _folderItemRepository.CreateAsync(newFolder);
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
            var folderDtoList = new List<FolderReadDto>();

            foreach (var folder in folders)
            {
                var folderDto = new FolderReadDto
                {
                    Id = folder.Id,
                    Name = folder.Name,
                    CreatedAt = folder.CreatedAt,
                    CreatedBy = folder.CreatedBy,
                    ModifiedAt = folder.ModifiedAt,
                    ModifiedBy = folder.ModifiedBy,
                    ParentId = folder.ParentId,
                };
                folderDtoList.Add(folderDto);
            }

            return Result<IEnumerable<FolderReadDto>>.Ok($"{folderDtoList.Count} folder(s) retrieved", folderDtoList);
        }

        public async Task<ResponseObject<FolderReadDto>> GetFolderByIdAsync(string id)
        {
            var folder = await _folderItemRepository.GetByIdAsync(id);
            if (folder is null)
            {
                return Result<FolderReadDto>.NotFound($"Folder with ID {id} not found");
            }

            var folderDto = new FolderReadDto
            {
                Id = folder.Id,
                Name = folder.Name,
                CreatedAt = folder.CreatedAt,
                CreatedBy = folder.CreatedBy,
                ModifiedAt = folder.ModifiedAt,
                ModifiedBy = folder.ModifiedBy,
                ParentId = folder.ParentId,
            };
            return Result<FolderReadDto>.Ok("Folder retrieved", folderDto);
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
