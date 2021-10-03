using System;
using System.Collections.Generic;
using MakeshiftReddit.Models.Entities;

namespace MakeshiftReddit.Models.ResponsesDtos
{
    public class GetPostsResponseDto
    {

        public string Description { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int UpVotes { get; set; }
        public int Downvotes { get; set; }
    }
}
