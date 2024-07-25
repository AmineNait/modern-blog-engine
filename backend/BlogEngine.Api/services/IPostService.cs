using BlogEngine.Api.Models;

namespace BlogEngine.Api.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPostsAsync(int pageNumber, int pageSize);
        Task<Post?> GetPostByIdAsync(int id);
        Task AddPostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(int id);
        Task<Post> CreatePostAsync(Post post);
    }
}
