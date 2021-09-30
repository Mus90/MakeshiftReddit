using System;
using System.Collections.Generic;

namespace MakeshiftReddit.Models.Entities
{
    public class Post
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public ICollection <Comment> Comments { get; set; }

    }
}
