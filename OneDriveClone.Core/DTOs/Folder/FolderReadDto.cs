using OneDriveClone.Core.DTOs.File;

namespace OneDriveClone.Core.DTOs.Folder
{
    public struct FolderReadDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? ParentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public ICollection<FolderReadDto> Subfolders { get; set; }
        public ICollection<FileReadDto> Files { get; set; }

        public FolderReadDto()
        {
            Id = string.Empty;
            Name = string.Empty;
            CreatedBy = string.Empty;
            ModifiedBy = string.Empty;

            Subfolders = [];
            Files = [];
        }
    }
}
