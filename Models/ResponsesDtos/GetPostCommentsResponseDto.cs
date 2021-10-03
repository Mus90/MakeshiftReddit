using System;
using System.Collections.Generic;
using MakeshiftReddit.Models.Entities;

namespace MakeshiftReddit.Models.ResponsesDtos
{
    public class GetPostCommentsResponseDto
    {
       
        public string Description { get; set; }
        public int UpVotes { get; set; }
        public int Downvotes { get; set; }
    }
}
