using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimedExercise.Services.LikeS;
using TimedExercise.Models.Like;
namespace TimedExercise.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }
        [HttpGet("/likePostId/{postId:int}")]
        public async Task<IActionResult> GetLikeDetails([FromRoute] int postId)
        {
            LikeDetails? detail = await _likeService.GetLikeDetailsAsync(postId);
            return detail is not null ? Ok(detail) : NotFound();
        }


    }
}