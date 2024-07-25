using BlogEngine.Api.Data;
using BlogEngine.Api.Models;
using BlogEngine.Api.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class CategoryServiceTests
{
    private BlogContext GetDbContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<BlogContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        return new BlogContext(options);
    }

    [Fact]
    public async Task GetCategoriesAsync_ReturnsAllCategories()
    {
        var context = GetDbContext(nameof(GetCategoriesAsync_ReturnsAllCategories));
        context.Categories.Add(new Category
        {
            Name = "TestCategory",
            Posts = new List<Post>()
        });
        await context.SaveChangesAsync();

        var service = new CategoryService(context);
        var categories = await service.GetCategoriesAsync();

        Assert.Single(categories);
    }

    [Fact]
    public async Task CreateCategoryAsync_AddsCategory()
    {
        var context = GetDbContext(nameof(CreateCategoryAsync_AddsCategory));
        var service = new CategoryService(context);

        var newCategory = new Category
        {
            Name = "NewCategory",
            Posts = new List<Post>()
        };

        var createdCategory = await service.CreateCategoryAsync(newCategory);

        Assert.Equal("NewCategory", createdCategory.Name);
        Assert.NotEqual(0, createdCategory.Id); // Vérifie que l'ID est défini
    }

    [Fact]
    public async Task UpdateCategoryAsync_UpdatesCategory()
    {
        var context = GetDbContext(nameof(UpdateCategoryAsync_UpdatesCategory));
        var category = new Category
        {
            Name = "OldName",
            Posts = new List<Post>()
        };
        context.Categories.Add(category);
        await context.SaveChangesAsync();

        var service = new CategoryService(context);
        category.Name = "UpdatedName";
        await service.UpdateCategoryAsync(category);

        var updatedCategory = await context.Categories.FindAsync(category.Id);
        Assert.Equal("UpdatedName", updatedCategory.Name);
    }

    [Fact]
    public async Task DeleteCategoryAsync_RemovesCategory()
    {
        var context = GetDbContext(nameof(DeleteCategoryAsync_RemovesCategory));
        var category = new Category
        {
            Name = "CategoryToDelete",
            Posts = new List<Post>()
        };
        context.Categories.Add(category);
        await context.SaveChangesAsync();

        var service = new CategoryService(context);
        await service.DeleteCategoryAsync(category.Id);

        var deletedCategory = await context.Categories.FindAsync(category.Id);
        Assert.Null(deletedCategory);
    }
}
