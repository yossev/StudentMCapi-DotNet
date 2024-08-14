using Microsoft.EntityFrameworkCore;
using StudentMCapi_DotNet.Entity;

namespace StudentMCapi_DotNet.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 


        }
        public DbSet<Student> Students { get; set; }

    }
}
