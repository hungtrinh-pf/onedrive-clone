namespace OneDriveClone.Core.DTOs.Folder
{
    public struct FolderCreateDto
    {
        public required string Name { get; set; }
        public string? ParentId { get; set; }
        public required string CreatedBy { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
