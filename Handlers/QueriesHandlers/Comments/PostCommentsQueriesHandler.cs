using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MakeshiftReddit.Models.Entities;
using MakeshiftReddit.Models.RequestsDtos;
using MakeshiftReddit.Models.ResponsesDtos;
using Microsoft.EntityFrameworkCore;

namespace MakeshiftReddit.Handlers.QueriesHandlers.Posts
{
    public class PostCommentsQueriesHandler : IPostCommentsQueriesHandler
    {
        //Calling database Context
        private readonly MyDbContext _context;
        private IMapper _mapper;

        public PostCommentsQueriesHandler(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GetPostComments
        public async Task<List<GetPostCommentsResponseDto>> GetPostComments(int id)
        {
            var result = await _context.Comments
                .Where(x => x.PostId == id)
                .Include(x => x.Votes)
                .Select(x=>new GetPostCommentsResponseDto
                {
                    Description= x.Description,
                    UpVotes = x.Votes.Count(x=>x.VoteValue==1),
                    Downvotes = x.Votes.Count(x=>x.VoteValue==-1)
                })
                .ToListAsync();
                
                
            var mapped = _mapper.Map<List<GetPostCommentsResponseDto>>(result);
            return mapped;

        }
    }
}
