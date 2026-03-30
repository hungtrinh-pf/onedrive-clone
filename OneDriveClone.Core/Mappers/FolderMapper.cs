using OneDriveClone.Core.DTOs.Folder;
using OneDriveClone.Core.Entities;

namespace OneDriveClone.Core.Mappers
{
    public class FolderMapper
    {
        public static FolderReadDto ToReadDto(FolderItem folder)
        {
            return new FolderReadDto
            {
                Id = folder.Id,
                Name = folder.Name,
                CreatedAt = folder.CreatedAt,
                CreatedBy = folder.CreatedBy,
                ModifiedAt = folder.ModifiedAt,
                ModifiedBy = folder.ModifiedBy,
                ParentId = folder.ParentId,
                Subfolders = folder.Subfolders.Count == 0 ? []
                    : [.. folder.Subfolders.Select(subfolder => ToReadDto(subfolder) with { Subfolders = [] })],
                Files = [.. folder.Files.Select(file => FileMapper.ToReadDto(file))],
            };
        }

        public static FolderItem ToFolder(FolderCreateDto createDto)
        {
            return new FolderItem
            {
                Id = createDto.ParentId is not null ? $"{Guid.NewGuid()}" : "root",
                Name = createDto.Name,
                ParentId = createDto.ParentId,
                CreatedAt = DateTime.Now,
                CreatedBy = createDto.CreatedBy,
                ModifiedAt = DateTime.Now,
                ModifiedBy = createDto.ModifiedBy,
            };
        }
    }
}
