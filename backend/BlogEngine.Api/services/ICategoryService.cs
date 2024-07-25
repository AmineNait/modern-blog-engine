using BlogEngine.Api.Models;

namespace BlogEngine.Api.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync(int pageNumber, int pageSize);
        Task<Category?> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int id);
        Task<Category> CreateCategoryAsync(Category category);
    }
}
