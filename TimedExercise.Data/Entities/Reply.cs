using System;
using System.Collections.Generic;

namespace TimedExercise.Data.Entities;

public partial class Reply
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public int AuthorId { get; set; }

    public int ParentId { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual Comment Parent { get; set; } = null!;
}
