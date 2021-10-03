using System;
using System.Threading.Tasks;
using AutoMapper;
using MakeshiftReddit.Models.Entities;
using MakeshiftReddit.Models.RequestsDtos;

namespace MakeshiftReddit.Handlers.CommandsHandlers
{
    public class CommentsCommandHandler : ICommentsCommandHandler
    {

        //Calling database Context
        private readonly MyDbContext _context;
        private IMapper _mapper;

        public CommentsCommandHandler(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // CreateCommentHandler

        public async Task<bool> CreateCommentHandler(CommentItemRequestDto input,string UserName)
        {
            try
            {
                var comment = _mapper.Map<Comment>(input);
                comment.UserName = UserName;
                await _context.Comments.AddAsync(comment);

                _context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }

        }
        //DeleteCommentHandler
        public async Task<bool> DeleteCommentHandler(int ID)
        {
            try
            {
                var comment = await _context.Comments.FindAsync(ID);
                _context.Remove(comment);
                _context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }

        }

        //UpdateCommentHandler
        public async Task<bool> UpdateCommentHandler(CommentItemRequestDto input)
        {
            try
            {
                var comment = _mapper.Map<Comment>(input);
                _context.Comments.Update(comment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }



        }
    }
}
