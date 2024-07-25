using Microsoft.EntityFrameworkCore;
using BlogEngine.Api.Models;

namespace BlogEngine.Api.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
