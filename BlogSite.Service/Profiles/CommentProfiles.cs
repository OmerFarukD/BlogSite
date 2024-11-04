using AutoMapper;
using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using BlogSite.Models.Entities;


namespace BlogSite.Service.Profiles;

public class CommentProfiles : Profile
{
    public CommentProfiles()
    {
        CreateMap<CommentAddRequestDto, Comment>();
        CreateMap<Comment, CommentResponseDto>()
            .ForMember(x => x.PostTitle, opt => opt.MapFrom(x => x.Post.Title))
            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User.UserName));
    }
}
