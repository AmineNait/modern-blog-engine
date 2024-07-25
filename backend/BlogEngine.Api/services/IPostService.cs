using BlogEngine.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogEngine.Api.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPostsAsync();
        Task<Post?> GetPostByIdAsync(int id);
        Task AddPostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
        Task<Post> CreatePostAsync(Post post);
    }
}
