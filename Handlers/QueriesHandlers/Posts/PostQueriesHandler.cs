using System;
using System.Collections.Generic;
using AutoMapper;
using MakeshiftReddit.Models.Entities;
using MakeshiftReddit.Models.RequestsDtos;
using MakeshiftReddit.Models.ResponsesDtos;
using Microsoft.EntityFrameworkCore;

namespace MakeshiftReddit.Handlers.QueriesHandlers.Posts
{
    public class PostQueriesHandler
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
        public List<GetPostsResponseDto> GetPostsByUser(PostItemRequestDto input)
        {
            return null;
        }


        //GetUserPosts



        //GetUserVotedPosts
    }
}
