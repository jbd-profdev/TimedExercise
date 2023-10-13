using TimedExercise.Models.Comment;

namespace TimedExercise.Services.CommentS;

public interface ICommentService
{
    Task<bool> CreateCommentAsync(int authorId, int postId, CommentCreate request);
    Task<CommentDetail?> GetCommentByPostIdAsync(int postId);
    Task<CommentDetail?> GetCommentByAuthorIdAsync(int authorId);
}