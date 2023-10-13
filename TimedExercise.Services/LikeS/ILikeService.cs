using TimedExercise.Models.Like;
using TimedExercise.Services.LikeS;

namespace TimedExercise.Services.LikeS
{
    public interface ILikeService
    {
        Task<LikeDetails?> GetLikeDetailsAsync(int postId);

    }
}