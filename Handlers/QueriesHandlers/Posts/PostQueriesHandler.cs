using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MakeshiftReddit.Models.Entities;
using MakeshiftReddit.Models.RequestsDtos;
using MakeshiftReddit.Models.ResponsesDtos;
using Microsoft.EntityFrameworkCore;

namespace MakeshiftReddit.Handlers.QueriesHandlers.Posts
{
    public class PostQueriesHandler : IPostQueriesHandler
    {


        //Calling database Context
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;
        public PostQueriesHandler(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //GetPostsByUserName
        public List<GetPostsResponseDto> GetPostsByUser(string userName)
        {
            return GetPosts(userName);

        }

        private List<GetPostsResponseDto> GetPosts(string userName)
        {
            var posts = _context.Posts
                            .Where(x => x.UserName == userName)
                            .Include(x => x.Votes)
                            .Include(x => x.Comments)
                            .Select(x => new GetPostsResponseDto
                            {
                                Description = x.Description,
                                Comments = x.Comments,
                                Downvotes = x.Votes.Count(x => x.VoteValue == -1),
                                UpVotes = x.Votes.Count(x => x.VoteValue == 1)
                            }).ToList();

            return posts;
        }


        //GetUserVotedPosts
        public List<GetPostsResponseDto> GetUserVotedPosts(string UserName)
        {
            var postsIds = _context.PostVotes.Where(x => x.UserName == UserName).Select(x => x.PostId).ToList();
            var posts = _context.Posts
                .Where(x => postsIds.Contains(x.ID))
                .Include(x => x.Votes)
                            .Include(x => x.Comments)
                            .Select(x => new GetPostsResponseDto
                            {
                                Description = x.Description,
                                Comments = x.Comments,
                                Downvotes = x.Votes.Count(x => x.VoteValue == -1),
                                UpVotes = x.Votes.Count(x => x.VoteValue == 1)
                            }).ToList();
            ;

            return posts;

        }
    }
}
