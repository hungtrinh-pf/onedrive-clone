using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneDriveClone.API.Helpers;
using OneDriveClone.BLL.IService;
using OneDriveClone.Core.DTOs.File;
using OneDriveClone.Core.Response;

namespace OneDriveClone.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FileController(IFileItemService fileItemService) : ControllerBase
    {
        private readonly IFileItemService _fileItemService = fileItemService;

        [HttpGet]
        public async Task<IActionResult> GetFiles()
        {
            var response = await _fileItemService.GetAllFilesAsync();
            return new ApiResponse<IEnumerable<FileReadDto>>(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFileData(string id)
        {
            try
            {
                var file = await _fileItemService.GetFileAsync(id);
                return File(file.Content!, file.Type);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateFile([FromForm] FileUploadForm uploadForm)
        {
            if (uploadForm.File.Length > 5_000_000)
            {
                var errorResponse = Result<int>.BadRequest("Upload file must be under 5 MB");
                return new ApiResponse<int>(errorResponse);
            }

            using var memoryStream = new MemoryStream();
            await uploadForm.File.CopyToAsync(memoryStream);

            var fileDto = new FileCreateDto
            {
                Name = uploadForm.File.FileName,
                Type = uploadForm.File.ContentType,
                FolderId = uploadForm.FolderId,
                CreatedBy = uploadForm.CreatedBy,
                ModifiedBy = uploadForm.ModifiedBy,
                Content = memoryStream.ToArray()
            };

            var response = await _fileItemService.CreateFileAsync(fileDto);
            return new ApiResponse<int>(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFile([FromBody] FileUpdateDto item, string id)
        {
            var response = await _fileItemService.UpdateFileAsync(id, item);
            return new ApiResponse<int>(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(string id)
        {
            var response = await _fileItemService.DeleteFileAsync(id);
            return new ApiResponse<int>(response);
        }
    }
}
