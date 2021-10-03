using System;
namespace MakeshiftReddit.Models.RequestsDtos
{
    public class PostVoteItemRequestDto
    {
        public int PostId { get; set; }
        public int VoteValue { get; set; }

    }
}
