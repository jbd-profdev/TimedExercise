using System.ComponentModel.DataAnnotations;

namespace TimedExercise.Models.Comment;

public class CommentCreate
{
    public string Text { get; set; } = string.Empty;

    [Required]
    public int AuthorId { get; set; }

    [Required]
    public int PostId { get; set; }
}