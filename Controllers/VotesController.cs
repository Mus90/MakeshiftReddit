using System;
using System.Threading.Tasks;
using MakeshiftReddit.Handlers.CommandsHandlers;
using MakeshiftReddit.Models.RequestsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MakeshiftReddit.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class VotesController : ControllerBase
        {
            //Calling database Context
            private readonly IVoteCommandHandler _commands;
            
            public VotesController(IVoteCommandHandler commands)
            {
                _commands = commands;
            }

        [HttpPost("CreatePostVote")]
            //CreatePostVote
        public async Task<IActionResult> CreatePostVote(PostVoteItemRequestDto input)
        {
            if (!ModelState.IsValid )
            {
                return BadRequest();
            }
            var result = await _commands.CreatePostVoteHandler(input,User.Identity.Name);
            return Ok(result);
        }

        [HttpPost("CreateCommentVote")]
        //CreateCommentVote
        public async Task<IActionResult> CreateCommentVote(CommentVoteItemRequestDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _commands.CreateCommentVoteHandler(input, User.Identity.Name);
            return Ok(result);
        }
    }
}
