using Microsoft.AspNetCore.Mvc;
using TimedExercise.Models.Comment;
using TimedExercise.Services.CommentS;

namespace TimedExercise.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;
    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    // [HttpPost]
    // public async Task<IActionResult> CreateComment([FromBody] CommentCreate request)
    // {
    //     if (!ModelState.IsValid)
    //         return BadRequest(ModelState);

    //     var response = await _commentService.CreateCommentAsync(request);
    //     if (response is not null)
    //         return Ok(response);

    //     return BadRequest();
    // }

    [HttpGet("/commentPostId/{postId:int}")]
    public async Task<IActionResult> GetCommentByPostId([FromRoute] int postId)
    {
        CommentDetail? detail = await _commentService.GetCommentByPostIdAsync(postId);
        return detail is not null ? Ok(detail) : NotFound();
    }

    [HttpGet("/commentAuthorId/{authorId:int}")]
    public async Task<IActionResult> GetCommentByAuthorId([FromRoute] int authorId)
    {
        CommentDetail? detail = await _commentService.GetCommentByAuthorIdAsync(authorId);
        return detail is not null ? Ok(detail) : NotFound();
    }
}