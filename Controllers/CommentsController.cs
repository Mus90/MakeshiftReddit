using System;
using System.Threading.Tasks;
using MakeshiftReddit.Handlers.CommandsHandlers;
using MakeshiftReddit.Handlers.QueriesHandlers.Posts;
using MakeshiftReddit.Models.RequestsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MakeshiftReddit.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CommentsController : ControllerBase
    {
        //Calling database Context
        private readonly ICommentsCommandHandler _commands;
        private readonly IPostCommentsQueriesHandler _queries;
        public CommentsController(IPostCommentsQueriesHandler queries, ICommentsCommandHandler commands)
        {
            _queries = queries;
            _commands = commands;
        }

        //GetPostComments
        [HttpGet ("{id}")]
        public async Task<IActionResult> GetPostComments(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _queries.GetPostComments(id);
            return Ok(result);
        }


        //CreateComment
        [HttpPost]
        public async Task <IActionResult> CreateComment([FromBody]CommentItemRequestDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
           var result = await _commands.CreateCommentHandler(input, User.Identity.Name);
            return Ok(result);
        }


        //UpdateComment
        [HttpPut]
        public async Task<IActionResult> UpdateComment([FromBody]CommentItemRequestDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
           var result =  await _commands.UpdateCommentHandler(input);
            return Ok(result);
        }

        [HttpDelete]
        //DeleteComment
        public async Task<IActionResult> DeleteComment([FromQuery]int id)
        {
           var result = await _commands.DeleteCommentHandler(id);
            return Ok(result);
        }
    }
}
