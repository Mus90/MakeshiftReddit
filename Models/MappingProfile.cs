using System;
using AutoMapper;
using MakeshiftReddit.Models.Entities;
using MakeshiftReddit.Models.RequestsDtos;
using MakeshiftReddit.Models.ResponsesDtos;

namespace MakeshiftReddit.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreatePostItemRequestDto, Post>();
            CreateMap<UpdatePostItemRequestDto, Post>();
            CreateMap<CommentItemRequestDto, Comment>();
            CreateMap<Comment, GetPostCommentsResponseDto>();
            CreateMap<PostVoteItemRequestDto, PostVotes>();
            CreateMap<CommentVoteItemRequestDto, CommentVotes>();
            CreateMap<Post, GetPostsResponseDto>();
        }
    }
}
