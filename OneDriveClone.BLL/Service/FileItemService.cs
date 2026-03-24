using OneDriveClone.BLL.IService;
using OneDriveClone.Core.DTOs;
using OneDriveClone.Core.Entities;
using OneDriveClone.Core.Response;
using OneDriveClone.DAL.IRepository;

namespace OneDriveClone.BLL.Service
{
    public class FileItemService(IFileItemRepository fileItemRepository) : IFileItemService
    {
        private readonly IFileItemRepository _fileItemRepository = fileItemRepository;

        public async Task<ResponseObject<int>> CreateFileAsync(FileCreateDto item)
        {
            var file = new FileItem
            {
                Id = $"{Guid.NewGuid()}",
                Name = item.Name,
                Type = item.Type,
                FolderId = item.FolderId,
                CreatedAt = DateTime.Now,
                CreatedBy = item.CreatedBy,
                ModifiedAt = DateTime.Now,
                ModifiedBy = item.ModifiedBy,
                Content = item.Content,
            };

            int createdCount = await _fileItemRepository.CreateAsync(file);
            return Result<int>.Created($"{createdCount} file(s) uploaded", createdCount);
        }

        public async Task<ResponseObject<int>> DeleteFileAsync(string id)
        {
            var deletedCount = await _fileItemRepository.DeleteAsync(id);
            if (deletedCount == -1)
            {
                return Result<int>.NotFound($"File with ID {id} not found");
            }
            return Result<int>.NoContent($"{deletedCount} file(s) deleted");
        }

        public async Task<ResponseObject<IEnumerable<FileReadDto>>> GetAllFilesAsync()
        {
            var files = await _fileItemRepository.GetAllAsync();
            var fileDtoList = new List<FileReadDto>();

            foreach (var file in files)
            {
                var fileDto = new FileReadDto
                {
                    Id = file.Id,
                    Name = file.Name,
                    Type = file.Type,
                    FolderId = file.FolderId,
                    CreatedAt = file.CreatedAt,
                    CreatedBy = file.CreatedBy,
                    ModifiedAt = file.ModifiedAt,
                    ModifiedBy = file.ModifiedBy,
                };
                fileDtoList.Add(fileDto);
            }

            return Result<IEnumerable<FileReadDto>>.Ok($"{fileDtoList.Count} file(s) retrieved", fileDtoList);
        }

        public async Task<FileReadDto> GetFileAsync(string id)
        {
            var file = await _fileItemRepository.GetByIdAsync(id) ?? throw new Exception($"File with ID {id} not found");
            return new FileReadDto
            {
                Id = file.Id,
                Name = file.Name,
                Type = file.Type,
                FolderId = file.FolderId,
                CreatedAt = file.CreatedAt,
                CreatedBy = file.CreatedBy,
                ModifiedAt = file.ModifiedAt,
                ModifiedBy = file.ModifiedBy,
                Content = file.Content,
            };
        }

        public async Task<ResponseObject<int>> UpdateFileAsync(string id, FileUpdateDto newItem)
        {
            var updatedCount = await _fileItemRepository.UpdateAsync(id, newItem);
            if (updatedCount == -1)
            {
                return Result<int>.NotFound($"File with ID {id} not found");
            }
            return Result<int>.NoContent($"{updatedCount} file(s) updated");
        }
    }
}
