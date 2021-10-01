using System;
namespace MakeshiftReddit.Models.RequestsDtos
{
    public class VoteItemRequestDto
    {
        public int ID { get; set; }
        public enum VoteValue
        {
            Upvote = 1,
            DownVote = -1
        }
    }
}
