using TimedExercise.Services.PostS;
using TimedExercise.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TimedExercise.Models.Post;
using TimedExercise.Data;

namespace TimedExercise.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly SocialMediaDbContext _db;
    public PostController(SocialMediaDbContext db)
    {
        _db = db;
    }
    private readonly IPostService _postService;
    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] PostCreate post)
    {
        Post newPost = new()
        {
            Title = post.Title,
            Text = post.Text
        };

        _db.Posts.Add(newPost);
        await _db.SaveChangesAsync();

        return Ok(newPost);
    }

}