using Microsoft.AspNetCore.Http.HttpResults;
using TimedExercise.Data;
using TimedExercise.Data.Entities;
using TimedExercise.Models.Post;

namespace TimedExercise.Services.PostS;

public class PostService : IPostService
{
    private SocialMediaDbContext _context;

    public PostService(SocialMediaDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreatePostAsync(PostCreate model)
    {
        Post entity = new()
        {
            Title = model.Title,
            Text = model.Text
        };

        _context.Posts.Add(entity);
        await _context.SaveChangesAsync();

        return true;
    }
}