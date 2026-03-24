using OneDriveClone.BLL.Helpers;

namespace OneDriveClone.API.Helpers
{
    public static class DependencyHelper
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddServiceLayer();
        }
    }
}
