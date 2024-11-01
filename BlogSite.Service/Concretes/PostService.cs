
using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstratcts;
using BlogSite.Service.Rules;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public sealed class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    private readonly PostBusinessRules _businessRules;

    public PostService(IPostRepository postRepository, IMapper mapper, PostBusinessRules rules)
    {
        _postRepository = postRepository;
        _mapper = mapper;
        _businessRules = rules;
    }

    public ReturnModel<PostResponseDto> Add(CreatePostRequest create, string userId)
    {
        Post createdPost = _mapper.Map<Post>(create);
        createdPost.Id = Guid.NewGuid();
        createdPost.AuthorId = userId;


        // iş kuralı
        _postRepository.Add(createdPost);

        PostResponseDto response = _mapper.Map<PostResponseDto>(createdPost);

        return new ReturnModel<PostResponseDto>
        {
            Data = response,
            Message = "Post Eklendi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAll()
    {
        List<Post> posts = _postRepository.GetAll();
        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);


        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            Message= string.Empty,
            StatusCode = 200,
            Success = true
        };

    }

    public ReturnModel<List<PostResponseDto>> GetAllByAuthorId(string id)
    {
        var posts = _postRepository.GetAll(x=> x.AuthorId==id,false);
        var responses = _mapper.Map<List<PostResponseDto>>(posts);

        return new ReturnModel<List<PostResponseDto>>
        {
            Data = responses,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int id)
    {
        throw new NotImplementedException();
    }


    // GetById_WhenPostIsNotPresent_ThrowsException()
    // GetById_WhenPostIsPresent_ReturnsSuccess()
    public ReturnModel<PostResponseDto?> GetById(Guid id)
    {
        var post = _postRepository.GetById(id);
        _businessRules.PostIsNullCheck(post);

        var response = _mapper.Map<PostResponseDto>(post);

        return new ReturnModel<PostResponseDto?>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };

    }

    public ReturnModel<PostResponseDto> Remove(Guid id)
    {
        Post post = _postRepository.GetById(id);

       
        Post deletedPost = _postRepository.Remove(post);

        PostResponseDto response = _mapper.Map<PostResponseDto>(deletedPost);

        return new ReturnModel<PostResponseDto>
        {
            Data = response,
            Message = "Post Silindi.",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<PostResponseDto> Update(UpdatePostRequest updatePost)
    {


        Post post = _postRepository.GetById(updatePost.Id);

        Post update = new Post
        {
            CategoryId = post.CategoryId,
            Content = updatePost.Content,
            Title = updatePost.Title,
            AuthorId = post.AuthorId,
            CreatedDate = post.CreatedDate,
        };

        Post updatedPost = _postRepository.Update(update);

        PostResponseDto dto = _mapper.Map<PostResponseDto>(updatedPost);
        return new ReturnModel<PostResponseDto>
        {
            Data = dto,
            Message = "Post güncellendi",
            StatusCode = 200,
            Success = true
        };


    }
}
