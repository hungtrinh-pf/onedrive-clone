using Microsoft.Extensions.DependencyInjection;
using OneDriveClone.BLL.IService;
using OneDriveClone.BLL.Service;
using OneDriveClone.DAL.Helpers;

namespace OneDriveClone.BLL.Helpers
{
    public static class DependencyHelper
    {
        public static void AddServiceLayer(this IServiceCollection services)
        {
            services.AddDataAccessLayer();

            services.AddScoped<IFileItemService, FileItemService>();
            services.AddScoped<IFolderItemService, FolderItemService>();
        }
    }
}
