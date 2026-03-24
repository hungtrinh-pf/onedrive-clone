using Microsoft.Extensions.DependencyInjection;
using OneDriveClone.DAL.IRepository;
using OneDriveClone.DAL.Repository;

namespace OneDriveClone.DAL.Helpers
{
    public static class DependencyHelper
    {
        public static void AddDataAccessLayer(this IServiceCollection services)
        {
            services.AddScoped<IFileItemRepository, FileItemRepository>();
            services.AddScoped<IFolderItemRepository, FolderItemRepository>();
        }
    }
}
