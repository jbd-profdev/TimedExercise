using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TimedExercise.Data;
using TimedExercise.Data.Entities;
using TimedExercise.Models.Reply;

namespace TimedExercise.Services.ReplyS;

public class ReplyService : IReplyService
{
    private SocialMediaDbContext _context;
    public ReplyService(SocialMediaDbContext context)
    {
        _context = context;
    }
    public async Task<bool> CreateReplyAsync(int authorId, int commentId, ReplyCreate model)
    {
        Reply entity = new()
        {
            Text = model.Text,
            AuthorId = authorId,
            CommentId = commentId
        };

        _context.Replies.Add(entity);
        await _context.SaveChangesAsync();

        return true;
    }
}