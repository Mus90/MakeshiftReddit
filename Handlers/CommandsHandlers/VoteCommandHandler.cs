using System;
using System.Threading.Tasks;
using AutoMapper;
using MakeshiftReddit.Models.Entities;
using MakeshiftReddit.Models.RequestsDtos;

namespace MakeshiftReddit.Handlers.CommandsHandlers
{
    public class VoteCommandHandler : IVoteCommandHandler
    {
        //Calling database Context
        private readonly MyDbContext _context;
        private IMapper _mapper;

        public VoteCommandHandler(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        //CreatePostVoteHandler
        public async Task<bool> CreatePostVoteHandler(PostVoteItemRequestDto input,string UserName)
        {
            try
            {
                var postVote = _mapper.Map<PostVotes>(input);
                postVote.UserName = UserName;
                await _context.PostVotes.AddAsync(postVote);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // CreateCommentVoteHandler
        public async Task<bool> CreateCommentVoteHandler(CommentVoteItemRequestDto input,string UserName)
        {
            try
            {
                var commentVote = _mapper.Map<CommentVotes>(input);
                commentVote.UserName = UserName;
                await _context.CommentVotes.AddAsync(commentVote);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
