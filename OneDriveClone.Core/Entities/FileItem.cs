using System.ComponentModel.DataAnnotations;

namespace OneDriveClone.Core.Entities
{
    public class FileItem
    {
        [Key]
        public required string Id { get; set; }

        public required string Name { get; set; }
        public required string Type { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public required string ModifiedBy { get; set; }
        public byte[]? Content { get; set; }

        public required string FolderId { get; set; }
        public virtual FolderItem? Folder { get; set; }
    }
}
