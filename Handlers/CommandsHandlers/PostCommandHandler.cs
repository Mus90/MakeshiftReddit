using System;
using System.Threading.Tasks;
using AutoMapper;
using MakeshiftReddit.Models.Entities;
using MakeshiftReddit.Models.RequestsDtos;

namespace MakeshiftReddit.Handlers.CommandsHandlers
{
    public class PostCommandHandler
    {

        //Calling database Context
        private readonly MyDbContext _context;
        private IMapper _mapper;

        public PostCommandHandler(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
       //CreatePostHandler
       public async Task CreatePostHandler(PostItemRequestDto input)
        {
            var list = _mapper.Map<Post>(input);
            await _context.Posts.AddAsync(list);
            _context.SaveChanges();
        }

        // DeletePostHandler
        public async Task DeletePostHandler (PostItemRequestDto input)
        {
            var list = _mapper.Map<Post>(input);
            await _context.Posts.FindAsync(list.ID);
            if (list == null)
            {
                throw new Exception("Could not find Post");
            }
            _context.Remove(list);
        }

        // UpdatePostHandler
        public void  UpdatePostHandler(PostItemRequestDto input)
        {
            var list = _mapper.Map<Post>(input);
            _context.Posts.Update(list);
            _context.SaveChanges();
        }
    }
}
