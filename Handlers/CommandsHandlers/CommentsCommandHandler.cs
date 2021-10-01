using System;
using System.Threading.Tasks;
using AutoMapper;
using MakeshiftReddit.Models.Entities;
using MakeshiftReddit.Models.RequestsDtos;

namespace MakeshiftReddit.Handlers.CommandsHandlers
{
    public class CommentsCommandHandler
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

        public async Task CreateCommentHandler(CommentItemRequestDto input)
        {
            var list = _mapper.Map<Comment>(input);
            await _context.Comments.AddAsync(list);
            _context.SaveChanges();
        }
        //DeleteCommentHandler
        public async Task DeleteCommentHandler(CommentItemRequestDto input)
        {
            var list = _mapper.Map<Comment>(input);
            await _context.Comments.FindAsync(list.ID);
            if (list == null)
            {
                throw new Exception("Couldn't find Comment");
            }
            _context.Remove(list);
        }

        //UpdateCommentHandler
        public void UpdateCommentHandler(PostItemRequestDto input)
        {
            var list = _mapper.Map<Comment>(input);
            _context.Comments.Update(list);
            _context.SaveChanges();
        }
    }
}
