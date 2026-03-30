namespace OneDriveClone.Core.DTOs.Folder
{
    public struct FolderUpdateDto
    {
        public required string Name { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
