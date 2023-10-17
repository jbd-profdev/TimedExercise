using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimedExercise.Data;
using TimedExercise.Models.Comment;
using TimedExercise.Services.CommentS;

namespace TimedExercise.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;
    private readonly SocialMediaDbContext _db;
    public CommentController(ICommentService commentService, SocialMediaDbContext db)
    {
        _commentService = commentService;
        _db = db;
    }

    [HttpPost("create/{authorId:int}/{postId:int}")]
    public async Task<IActionResult> CreateComment(int authorId, int postId, [FromBody] CommentCreate request)
    {
        if (ModelState.IsValid)
        {
            var response = await _commentService.CreateCommentAsync(authorId, postId, request);
            if (response == true)
                return Ok(response);
        }
        return BadRequest(ModelState);
    }

    // [HttpGet("/commentPostId/{postId:int}")]
    // public async Task<IActionResult> GetCommentByPostId([FromRoute] int postId)
    // {
    //     CommentDetail? detail = await _commentService.GetCommentByPostIdAsync(postId);
    //     return detail is not null ? Ok(detail) : NotFound();
    // }

    [HttpGet("/commentAuthorId/{authorId:int}")]
    public async Task<IActionResult> GetCommentByAuthorId([FromRoute] int authorId)
    {
        CommentDetail? detail = await _commentService.GetCommentByAuthorIdAsync(authorId);
        return detail is not null ? Ok(detail) : NotFound();
    }

    [HttpGet("/commentPostId/{postId:int}")]
    public async Task<IActionResult> GetCommentsForPost(int postId)
    {
        var comments = await _db.Comments.Where(c => c.PostId == postId).ToListAsync();
        return Ok(comments);
    }
}