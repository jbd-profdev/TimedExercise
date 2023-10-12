using System;
using System.Collections.Generic;

namespace TimedExercise.Data.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public int AuthorId { get; set; }

    public int PostId { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual Post Post { get; set; } = null!;

    public virtual ICollection<Reply> Replies { get; set; } = new List<Reply>();
}
