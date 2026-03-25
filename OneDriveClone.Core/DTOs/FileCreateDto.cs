namespace OneDriveClone.Core.DTOs
{
    public struct FileCreateDto
    {
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string FolderId { get; set; }
        public required string CreatedBy { get; set; }
        public required string ModifiedBy { get; set; }
        public byte[]? Content { get; set; }
    }
}
