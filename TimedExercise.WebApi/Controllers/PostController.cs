using TimedExercise.Services.PostS;
using TimedExercise.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TimedExercise.Models.Post;
using TimedExercise.Data;
using TimedExercise.Services.UserS;
using Microsoft.EntityFrameworkCore;

namespace TimedExercise.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly SocialMediaDbContext _db;
    private readonly IPostService _postService;

    private readonly IUserService _userService;
    public PostController(SocialMediaDbContext db, IPostService postService, IUserService userService)
    {
        _db = db;
        _postService = postService;
        _userService = userService;
    }

    [HttpPost("~/api/Post/{authorId:int}")]
    public async Task<IActionResult> CreatePost(int authorId, [FromBody] PostCreate request)
    {
        var response = await _postService.CreatePostAsync(authorId, request);
        if(response == true )
            return Ok(response);
        return BadRequest();
    }

    [HttpGet("~/api/Post")]
    public async Task<IActionResult> GetAllPosts()
    {
        var posts = await _db.Posts.ToListAsync();
        return Ok(posts);
    }
}