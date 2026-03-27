namespace OneDriveClone.Core.DTOs
{
    public struct FileReadDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string FolderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public byte[]? Content { get; set; }

        public FileReadDto()
        {
            Id = string.Empty;
            Name = string.Empty;
            Type = string.Empty;
            FolderId = string.Empty;
            CreatedBy = string.Empty;
            ModifiedBy = string.Empty;
        }
    }
}
