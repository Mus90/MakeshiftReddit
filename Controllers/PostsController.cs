using System;
using System.Threading.Tasks;
using MakeshiftReddit.Handlers.CommandsHandlers;
using MakeshiftReddit.Handlers.QueriesHandlers.Posts;
using MakeshiftReddit.Models.Entities;
using MakeshiftReddit.Models.RequestsDtos;
using MakeshiftReddit.Models.ResponsesDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MakeshiftReddit.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PostsController :ControllerBase
    {
        //Calling database Context
        private readonly IPostQueriesHandler _queries;
        private readonly IPostCommandHandler _commands;
        public PostsController(IPostQueriesHandler queries, IPostCommandHandler commands )
        {
            _queries = queries;
            _commands = commands;
        }


        //Get: api/Post
        [HttpGet("MyPosts")]
        public IActionResult GetMyPosts()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var currentuser = User.Identity.Name;
            var result = _queries.GetPostsByUser(currentuser);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //Get: api/Post
        [HttpGet("MyVotedPosts")]
        public IActionResult GetMyVotedPosts()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var currentuser = User.Identity.Name;
            var result = _queries.GetUserVotedPosts(currentuser);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        //Get: api/Post
        [HttpGet("{userName}")]
        public IActionResult GetPostsByUserName(string userName)
        {
            if (!ModelState.IsValid)
            {                return BadRequest();
            }
            var result = _queries.GetPostsByUser(userName);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //CreatePost
        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostItemRequestDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _commands.CreatePostHandler(input,User.Identity.Name);
            return Ok(result);
        }

        //Put 
        [HttpPut]
        public IActionResult UpdatePost (UpdatePostItemRequestDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
          var result = _commands.UpdatePostHandler(input);
            return Ok(result);
        }

        //DeletePost
        [HttpDelete]
        public async Task <IActionResult> DeletePost(int id)
        {
            var result = await _commands.DeletePostHandler(id);
            return Ok(result);
        }
    }
}
