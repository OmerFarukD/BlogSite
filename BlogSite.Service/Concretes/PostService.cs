
using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstratcts;

namespace BlogSite.Service.Concretes;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public Post Add(CreatePostRequest create)
    {
        Post post = _mapper.Map<Post>(create);
        Post createdPost = _postRepository.Add(post);

        return createdPost;
    }

    public List<PostResponseDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public PostResponseDto? GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}
