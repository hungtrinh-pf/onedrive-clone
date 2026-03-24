namespace OneDriveClone.API.Helpers
{
    public class FileUploadForm
    {
        public required string FolderId { get; set; }
        public required string CreatedBy { get; set; }
        public required string ModifiedBy { get; set; }
        public required IFormFile File { get; set; }
    }
}
