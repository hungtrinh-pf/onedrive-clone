using System.ComponentModel.DataAnnotations;

namespace OneDriveClone.Core.Entities
{
    public class FolderItem
    {
        [Key]
        public required string Id { get; set; }

        public required string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public required string ModifiedBy { get; set; }

        public string? ParentId { get; set; }
        public virtual FolderItem? Parent { get; set; }
        public virtual ICollection<FolderItem> Subfolders { get; set; } = [];
        public virtual ICollection<FileItem> Files { get; set; } = [];
    }
}
