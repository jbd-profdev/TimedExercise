using TimedExercise.Models.Post;
using TimedExercise.Data.Entities;
namespace TimedExercise.Services.PostS;

public interface IPostService
{
    Task<bool> CreatePostAsync(PostCreate model);
}