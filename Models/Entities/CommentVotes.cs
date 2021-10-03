using System;
using System.Collections.Generic;

namespace MakeshiftReddit.Models.Entities
{
    public class CommentVotes : Vote
    {
        public int CommentId { get; set; }
    }
}
