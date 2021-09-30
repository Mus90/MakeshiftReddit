using System;
namespace MakeshiftReddit.Models.Entities
{
    public class Vote
    {
        public int ID { get; set; }
        public enum VoteValue
        {
            Upvote = 1,
            DownVote = -1
        }
    }
}
