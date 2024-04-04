using AutoMapper;
using ENTITIES.DTOs;
using ENTITIES.Entities;

namespace WebApiBloggingPlatform
{
    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            CreateMap<Post, PostDTO>();
            CreateMap<PostDTO, Post>();

            CreateMap<Comment, CommentDTO>();
            CreateMap<CommentDTO, Comment>();
        }


    }
}
