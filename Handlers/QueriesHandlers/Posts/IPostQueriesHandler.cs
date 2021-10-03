using System.Collections.Generic;
using MakeshiftReddit.Models.ResponsesDtos;

namespace MakeshiftReddit.Handlers.QueriesHandlers.Posts
{
    public interface IPostQueriesHandler
    {
        List<GetPostsResponseDto> GetPostsByUser(string userName);
        List<GetPostsResponseDto> GetUserVotedPosts(string UserName);
    }
}