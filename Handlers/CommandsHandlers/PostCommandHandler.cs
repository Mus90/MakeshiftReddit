using System;
using System.Threading.Tasks;
using AutoMapper;
using MakeshiftReddit.Models.Entities;
using MakeshiftReddit.Models.RequestsDtos;

namespace MakeshiftReddit.Handlers.CommandsHandlers
{
    public class PostCommandHandler : IPostCommandHandler
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
        public async Task<bool> CreatePostHandler(CreatePostItemRequestDto input,string Username)
        {
            try
            {
                var post = _mapper.Map<Post>(input);
                post.UserName = Username;
                await _context.Posts.AddAsync(post);
                _context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }

        }

        // DeletePostHandler
        public async Task<bool> DeletePostHandler(int ID)
        {
            try
            {
                var post = await _context.Posts.FindAsync(ID);
                _context.Remove(post);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }

        // UpdatePostHandler
        public bool UpdatePostHandler(UpdatePostItemRequestDto input)
        {
            try
            {
                var list = _mapper.Map<Post>(input);
                _context.Posts.Update(list);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
