using System;
using System.Collections.Generic;

namespace TimedExercise.Data.Entities;

public partial class Post
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Text { get; set; } = null!;

    public string? Url { get; set; }

    public int AuthorId { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
}
