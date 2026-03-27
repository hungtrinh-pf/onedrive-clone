namespace OneDriveClone.Core.DTOs
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
