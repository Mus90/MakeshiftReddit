﻿using System;
namespace MakeshiftReddit.Models.RequestsDtos
{
    public class CommentItemRequestDto
    {
        public int PostId { get; set; }
        public string Description { get; set; }
    }
}
