using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TimedExercise.Data;
using TimedExercise.Models.Reply;
using TimedExercise.Services.ReplyS;
using TimedExercise.Services.UserS;
using static TimedExercise.Models.Reply.ReplyResponse;

namespace TimedExercise.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : ControllerBase
    {
        private readonly SocialMediaDbContext _db;
        private readonly IReplyService _replyService;

        private readonly IUserService _userService;
        public ReplyController(SocialMediaDbContext db,IReplyService replyService, IUserService userService)
        {
            _db = db;
            _replyService = replyService;
            _userService = userService;
        }
        [HttpPost("~/api/Reply/{authorId:int}")]
        public async Task<IActionResult> CreateReply(int authorId, int commentId, [FromBody] ReplyCreate request)
        {
            var response = await _replyService.CreateReplyAsync(authorId, commentId, request);
            if (response == true)
                return Ok(response);
            return BadRequest();
        }

        [HttpGet("~/api/Reply")]
        public async Task<IActionResult> GetRepliesByPost()
        {
            var replies = await _db.Replies.ToListAsync();
            return Ok(replies);
        }

    }
}