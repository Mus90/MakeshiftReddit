using System;
using System.Collections.Generic;

namespace MakeshiftReddit.Models.Entities
{
    public class Comment
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public int PostId { get; set; }
        public ICollection<CommentVotes> Votes { get; set; }
    }
}
