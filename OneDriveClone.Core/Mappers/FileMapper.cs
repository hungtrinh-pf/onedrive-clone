using OneDriveClone.Core.DTOs;
using OneDriveClone.Core.Entities;

namespace OneDriveClone.Core.Mappers
{
    public class FileMapper
    {
        public static FileReadDto ToReadDto(FileItem file, bool includeContent = false)
        {
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
                Content = includeContent ? file.Content : null,
            };
        }

        public static FileItem ToFile(FileCreateDto createDto)
        {
            return new FileItem
            {
                Id = $"{Guid.NewGuid()}",
                Name = createDto.Name,
                Type = createDto.Type,
                FolderId = createDto.FolderId,
                CreatedAt = DateTime.Now,
                CreatedBy = createDto.CreatedBy,
                ModifiedAt = DateTime.Now,
                ModifiedBy = createDto.ModifiedBy,
                Content = createDto.Content,
            };
        }
    }
}
