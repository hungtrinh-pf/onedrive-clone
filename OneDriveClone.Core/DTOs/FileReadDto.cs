namespace OneDriveClone.Core.DTOs
{
    public struct FileReadDto
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string FolderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public required string ModifiedBy { get; set; }
        public byte[]? Content { get; set; }
    }
}
