using Microsoft.EntityFrameworkCore;

namespace FullStack.Services.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
