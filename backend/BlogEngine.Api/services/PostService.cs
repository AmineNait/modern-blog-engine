using BlogEngine.Api.Data;
using BlogEngine.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogEngine.Api.Services
{
    public class PostService : IPostService
    {
        private readonly BlogContext _context;

        public PostService(BlogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            return post ?? throw new KeyNotFoundException("Post not found");
        }

        public async Task<Post> CreatePostAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task UpdatePostAsync(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                throw new KeyNotFoundException("Post not found");
            }
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}
