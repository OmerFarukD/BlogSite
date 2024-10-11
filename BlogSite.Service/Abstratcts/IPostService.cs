using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entities;

namespace BlogSite.Service.Abstratcts;

public interface IPostService
{
    List<PostResponseDto> GetAll();
    PostResponseDto? GetById(Guid id);
    Post Add(CreatePostRequest create);
}
