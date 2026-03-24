using Microsoft.AspNetCore.Mvc;
using OneDriveClone.BLL.IService;
using OneDriveClone.Core.DTOs;
using OneDriveClone.Core.Response;

namespace OneDriveClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController(IFolderItemService folderItemService) : ControllerBase
    {
        private readonly IFolderItemService _folderItemService = folderItemService;

        [HttpGet]
        public async Task<object> GetFolders(string? id)
        {
            if (id is not null)
            {
                var folderResponse = await _folderItemService.GetFolderByIdAsync(id);
                Response.StatusCode = folderResponse.StatusCode;
                return folderResponse;
            }
            
            var foldersResponse = await _folderItemService.GetAllFoldersAsync();
            Response.StatusCode = foldersResponse.StatusCode;
            return foldersResponse;
        }

        [HttpPost]
        public async Task<ResponseObject<int>> CreateFolder([FromBody] FolderCreateDto item)
        {
            var response = await _folderItemService.CreateFolderAsync(item);
            Response.StatusCode = response.StatusCode;
            return response;
        }

        [HttpPut]
        public async Task<ResponseObject<int>> UpdateFolder([FromBody] FolderUpdateDto item, string id)
        {
            var response = await _folderItemService.UpdateFolderAsync(id, item);
            Response.StatusCode = response.StatusCode;
            return response;
        }

        [HttpDelete]
        public async Task<ResponseObject<int>> DeleteFolder(string id)
        {
            var response = await _folderItemService.DeleteFolderAsync(id);
            Response.StatusCode = response.StatusCode;
            return response;
        }
    }
}
