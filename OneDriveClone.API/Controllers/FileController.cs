using Microsoft.AspNetCore.Mvc;
using OneDriveClone.API.Helpers;
using OneDriveClone.BLL.IService;
using OneDriveClone.Core.DTOs;
using OneDriveClone.Core.Response;

namespace OneDriveClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController(IFileItemService fileItemService) : ControllerBase
    {
        private readonly IFileItemService _fileItemService = fileItemService;

        [HttpGet]
        public async Task<ResponseObject<IEnumerable<FileReadDto>>> GetFiles()
        {
            var response = await _fileItemService.GetAllFilesAsync();
            Response.StatusCode = response.StatusCode;
            return response;
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
        public async Task<ResponseObject<int>> CreateFile([FromForm] FileUploadForm uploadForm)
        {
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
            Response.StatusCode = response.StatusCode;
            return response;
        }

        [HttpPut]
        public async Task<ResponseObject<int>> UpdateFile([FromBody] FileUpdateDto item, string id)
        {
            var response = await _fileItemService.UpdateFileAsync(id, item);
            Response.StatusCode = response.StatusCode;
            return response;
        }

        [HttpDelete]
        public async Task<ResponseObject<int>> DeleteFile(string id)
        {
            var response = await _fileItemService.DeleteFileAsync(id);
            Response.StatusCode = response.StatusCode;
            return response;
        }
    }
}
