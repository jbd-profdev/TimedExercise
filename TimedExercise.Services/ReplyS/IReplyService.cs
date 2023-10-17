using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimedExercise.Data.Entities;
using TimedExercise.Models.Reply;


namespace TimedExercise.Services.ReplyS;
    public interface IReplyService
    {
       Task<bool> CreateReplyAsync(int authorId,int commentId, ReplyCreate model);
    }
