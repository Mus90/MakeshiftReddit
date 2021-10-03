using System.Threading.Tasks;
using MakeshiftReddit.Models.RequestsDtos;

namespace MakeshiftReddit.Handlers.CommandsHandlers
{
    public interface IPostCommandHandler
    {
        Task<bool> CreatePostHandler(CreatePostItemRequestDto input,string UserName);
        Task<bool> DeletePostHandler(int ID);
        bool UpdatePostHandler(UpdatePostItemRequestDto input);
    }
}