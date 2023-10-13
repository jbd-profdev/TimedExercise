using TimedExercise.Models.Comment;

namespace TimedExercise.Services.CommentS;

public interface ICommentService
{
    // Task<CommentDetail?> CreateCommentAsync(CommentCreate request);
    Task<CommentDetail?> GetCommentByPostIdAsync(int postId);
    Task<CommentDetail?> GetCommentByAuthorIdAsync(int authorId);
}