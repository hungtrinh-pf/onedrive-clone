using Microsoft.EntityFrameworkCore;
using OneDriveClone.Core.Entities;

namespace OneDriveClone.DAL
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<FileItem> FileItems { get; set; }
        public DbSet<FolderItem> FolderItems { get; set; }
    }
}
