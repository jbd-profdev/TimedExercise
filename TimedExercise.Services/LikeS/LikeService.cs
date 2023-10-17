using Microsoft.EntityFrameworkCore;
using TimedExercise.Data;
using TimedExercise.Data.Entities;
using TimedExercise.Models.Like;

namespace TimedExercise.Services.LikeS;

public class LikeService : ILikeService
{
    private readonly SocialMediaDbContext _dbContext;
    public LikeService(SocialMediaDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<bool> CreateLikeAsync(int userId, int postId, LikeCreate model)
    {
        Like entity = new()
        {

            UserId = userId,
            PostId = postId,
        };

        _dbContext.Likes.Add(entity);
        await _dbContext.SaveChangesAsync();

        return true;
    }
    public async Task<LikeDetails?> GetLikeDetailsAsync(int postId)
    {
        Like? entity = await _dbContext.Likes
        .FirstOrDefaultAsync(e => e.PostId == postId);

        return entity is null ? null : new LikeDetails
        {
            Id = entity.Id,
            UserId = entity.UserId,
            PostId = entity.PostId
        };
    }


}
