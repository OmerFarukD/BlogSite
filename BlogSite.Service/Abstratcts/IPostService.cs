using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entities;
using Core.Responses;

namespace BlogSite.Service.Abstratcts;

public interface IPostService
{
    ReturnModel<List<PostResponseDto>> GetAll();
    ReturnModel<PostResponseDto?> GetById(Guid id);
    ReturnModel<PostResponseDto> Add(CreatePostRequest create, string userId);

    ReturnModel<PostResponseDto> Update(UpdatePostRequest updatePost);

    ReturnModel<PostResponseDto> Remove(Guid id);

    ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int id);

    ReturnModel<List<PostResponseDto>> GetAllByAuthorId(string id);
}
