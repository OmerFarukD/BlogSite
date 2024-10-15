using AutoMapper;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entities;

namespace BlogSite.Service.Profiles;

public class MappingProfiles: Profile
{

    public MappingProfiles()
    {
        CreateMap<CreatePostRequest, Post>();
        CreateMap<Post,PostResponseDto>();
    }
}
