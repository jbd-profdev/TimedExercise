using System.ComponentModel.DataAnnotations;

namespace TimedExercise.Models.Post;

public class PostCreate
{
    [Required, MinLength(1)]
    public string Title {get; set;} = string.Empty;
    [Required, MinLength(1)]
    public string Text {get; set;} = string.Empty;
    
}