namespace OneDriveClone.Core.DTOs
{
    public class FolderCreateDto
    {
        public required string Name { get; set; }
        public string? ParentId { get; set; }
        public required string CreatedBy { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
