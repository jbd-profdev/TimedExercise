using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TimedExercise.Services.ReplyS;

namespace TimedExercise.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReplyController : Controller
    {
        private readonly IReplyService _replyService;
        public ReplyController(IReplyService replyService)
        {
            _replyService = replyService;
        }
    }
}