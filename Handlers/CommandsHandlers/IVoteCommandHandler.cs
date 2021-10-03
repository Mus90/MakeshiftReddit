using System.Threading.Tasks;
using MakeshiftReddit.Models.RequestsDtos;

namespace MakeshiftReddit.Handlers.CommandsHandlers
{
    public interface IVoteCommandHandler
    {
        Task<bool> CreateCommentVoteHandler(CommentVoteItemRequestDto input,string UserName);
        Task<bool> CreatePostVoteHandler(PostVoteItemRequestDto input, string UserName);
    }
}