using ImageSaveIntoDB.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageSaveIntoDB.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
                
        }
        public DbSet<Student> Students { get; set; }

    }
}
