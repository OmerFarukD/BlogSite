using BlogSite.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.DataAccess.Contexts;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions opt): base(opt)
    {
        
    }


    public DbSet<Post> Posts { get; set; }
}
