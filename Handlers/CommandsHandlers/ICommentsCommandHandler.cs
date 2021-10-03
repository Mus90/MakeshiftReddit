using System.Threading.Tasks;
using MakeshiftReddit.Models.RequestsDtos;

namespace MakeshiftReddit.Handlers.CommandsHandlers
{
    public interface ICommentsCommandHandler
    {
        Task<bool> CreateCommentHandler(CommentItemRequestDto input,string UserName);
        Task<bool> DeleteCommentHandler(int ID);
        Task<bool> UpdateCommentHandler(CommentItemRequestDto input);
    }
}