using System;
using System.Collections.Generic;

namespace MakeshiftReddit.Models.Entities
{
    public class PostVotes : Vote
    {
        public int PostId { get; set; }

    }
}
