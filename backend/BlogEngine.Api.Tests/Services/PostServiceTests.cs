using BlogEngine.Api.Data;
using BlogEngine.Api.Models;
using BlogEngine.Api.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class PostServiceTests
{
    private BlogContext GetDbContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<BlogContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        return new BlogContext(options);
    }

    [Fact]
    public async Task GetPostsAsync_ReturnsAllPosts()
    {
        var context = GetDbContext(nameof(GetPostsAsync_ReturnsAllPosts));
        var category = new Category
        {
            Name = "TestCategory",
            Posts = new List<Post>()
        };
        context.Categories.Add(category);
        context.Posts.Add(new Post
        {
            Title = "TestPost",
            Content = "TestContent",
            Category = category
        });
        await context.SaveChangesAsync();

        var service = new PostService(context);
        var posts = await service.GetPostsAsync();

        Assert.Single(posts);
    }

    [Fact]
    public async Task CreatePostAsync_AddsPost()
    {
        var context = GetDbContext(nameof(CreatePostAsync_AddsPost));
        var category = new Category
        {
            Name = "TestCategory",
            Posts = new List<Post>()
        };
        context.Categories.Add(category);
        await context.SaveChangesAsync();

        var service = new PostService(context);
        var newPost = new Post
        {
            Title = "NewPost",
            Content = "NewContent",
            CategoryId = category.Id,
            Category = category
        };

        var createdPost = await service.CreatePostAsync(newPost);

        Assert.Equal("NewPost", createdPost.Title);
        Assert.NotEqual(0, createdPost.Id); // Vérifie que l'ID est défini
    }

    [Fact]
    public async Task UpdatePostAsync_UpdatesPost()
    {
        var context = GetDbContext(nameof(UpdatePostAsync_UpdatesPost));
        var category = new Category
        {
            Name = "TestCategory",
            Posts = new List<Post>()
        };
        context.Categories.Add(category);
        var post = new Post
        {
            Title = "OldTitle",
            Content = "OldContent",
            CategoryId = category.Id,
            Category = category
        };
        context.Posts.Add(post);
        await context.SaveChangesAsync();

        var service = new PostService(context);
        post.Title = "UpdatedTitle";
        await service.UpdatePostAsync(post);

        var updatedPost = await context.Posts.FindAsync(post.Id);
        Assert.Equal("UpdatedTitle", updatedPost.Title);
    }

    [Fact]
    public async Task DeletePostAsync_RemovesPost()
    {
        var context = GetDbContext(nameof(DeletePostAsync_RemovesPost));
        var category = new Category
        {
            Name = "TestCategory",
            Posts = new List<Post>()
        };
        context.Categories.Add(category);
        var post = new Post
        {
            Title = "PostToDelete",
            Content = "ContentToDelete",
            CategoryId = category.Id,
            Category = category
        };
        context.Posts.Add(post);
        await context.SaveChangesAsync();

        var service = new PostService(context);
        await service.DeletePostAsync(post.Id);

        var deletedPost = await context.Posts.FindAsync(post.Id);
        Assert.Null(deletedPost);
    }
}
