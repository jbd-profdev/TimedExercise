using System;
using System.Collections.Generic;

namespace TimedExercise.Data.Entities;

public partial class Like
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int PostId { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
