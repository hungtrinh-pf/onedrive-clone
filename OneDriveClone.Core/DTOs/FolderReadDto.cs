namespace OneDriveClone.Core.DTOs
{
    public class FolderReadDto
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public string? ParentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
