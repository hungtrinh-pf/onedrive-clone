using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OneDriveClone.API.Helpers;
using OneDriveClone.BLL.IService;
using OneDriveClone.Core.DTOs.Folder;

namespace OneDriveClone.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController(IFolderItemService folderItemService) : ControllerBase
    {
        private readonly IFolderItemService _folderItemService = folderItemService;

        [HttpGet]
        public async Task<IActionResult> GetFolders()
        {
            var foldersResponse = await _folderItemService.GetAllFoldersAsync();
            return new ApiResponse<IEnumerable<FolderReadDto>>(foldersResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFolderById(string id)
        {
            var folderResponse = await _folderItemService.GetFolderByIdAsync(id);
            return new ApiResponse<FolderReadDto>(folderResponse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFolder([FromBody] FolderCreateDto item)
        {
            var response = await _folderItemService.CreateFolderAsync(item);
            return new ApiResponse<int>(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFolder([FromBody] FolderUpdateDto item, string id)
        {
            var response = await _folderItemService.UpdateFolderAsync(id, item);
            return new ApiResponse<int>(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFolder(string id)
        {
            var response = await _folderItemService.DeleteFolderAsync(id);
            return new ApiResponse<int>(response);
        }
    }
}
