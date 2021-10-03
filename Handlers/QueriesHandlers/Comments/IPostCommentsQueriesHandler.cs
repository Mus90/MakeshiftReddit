using System.Collections.Generic;
using System.Threading.Tasks;
using MakeshiftReddit.Models.ResponsesDtos;

namespace MakeshiftReddit.Handlers.QueriesHandlers.Posts
{
    public interface IPostCommentsQueriesHandler
    {
        Task<List<GetPostCommentsResponseDto>> GetPostComments(int id);
    }
}