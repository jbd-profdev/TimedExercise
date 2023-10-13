using Microsoft.EntityFrameworkCore;
using TimedExercise.Data;
using TimedExercise.Data.Entities;
using TimedExercise.Models.Comment;

namespace TimedExercise.Services.CommentS;

public class CommentService : ICommentService
{
    private readonly SocialMediaDbContext _dbContext;
    public CommentService(SocialMediaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CreateCommentAsync(int authorId, int postId, CommentCreate request)
    {
        Comment entity = new()
        {
            Text = request.Text,
            AuthorId = authorId,
            PostId = postId
        };

        _dbContext.Comments.Add(entity);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<CommentDetail?> GetCommentByPostIdAsync(int postId)
    {
        Comment? entity = await _dbContext.Comments
            .FirstOrDefaultAsync(e => e.PostId == postId);

        return entity is null ? null : new CommentDetail
        {
            Id = entity.Id,
            Text = entity.Text,
            AuthorId = entity.AuthorId,
            PostId = entity.PostId
        };
    }

    public async Task<CommentDetail?> GetCommentByAuthorIdAsync(int authorId)
    {
        Comment? entity = await _dbContext.Comments
            .FirstOrDefaultAsync(e => e.AuthorId == authorId);

        return entity is null ? null : new CommentDetail
        {
            Id = entity.Id,
            Text = entity.Text,
            AuthorId = entity.AuthorId,
            PostId = entity.PostId
        };
    }
}