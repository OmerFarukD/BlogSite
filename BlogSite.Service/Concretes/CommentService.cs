using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstratcts;
using Core.Exceptions;
using Core.Responses;
namespace BlogSite.Service.Concretes;

public class CommentService(IMapper _mapper, ICommentRepository _repository) : ICommentService
{
    public ReturnModel<NoData> Add(CommentAddRequestDto dto, string userId)
    {
        Comment comment = _mapper.Map<Comment>(dto);
        comment.Id = Guid.NewGuid();
        comment.UserId = userId;

        _repository.Add(comment);


        return new ReturnModel<NoData>
        {
            Message = "Yorum eklendi.",
            StatusCode = 201,
            Success = true
        };


    }

    public ReturnModel<NoData> Delete(Guid id)
    {
        Comment comment = CheckById(id);

        _repository.Remove(comment);

        return new ReturnModel<NoData>
        {
            Message = "Yorum Silindi.",
            StatusCode = 200,
            Success = true
        };

    }

  

    public ReturnModel<List<CommentResponseDto>> GetAllByPostId(Guid postId)
    {
        var comments = _repository.GetAll(x=> x.PostId == postId);
        var responses = _mapper.Map<List<CommentResponseDto>>(comments);

        return new ReturnModel<List<CommentResponseDto>>
        {
            Data = responses,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<CommentResponseDto>> GetAllByUserId(string userId)
    {
        var comments = _repository.GetAll(x => x.UserId == userId);
        var responses = _mapper.Map<List<CommentResponseDto>>(comments);

        return new ReturnModel<List<CommentResponseDto>>
        {
            Data = responses,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CommentResponseDto> GetById(Guid id)
    {
        Comment comment = CheckById(id);
        var response = _mapper.Map<CommentResponseDto>(comment);

        return new ReturnModel<CommentResponseDto>
        {
            Data = response,
            StatusCode = 200,
            Success = true
        };
    }

    private Comment CheckById(Guid id)
    {
        Comment comment = _repository.GetById(id);
        if (comment is null)
        {
            throw new NotFoundException("İlgili Yorum bulunamadı.");
        }
        return comment;
    }
}
