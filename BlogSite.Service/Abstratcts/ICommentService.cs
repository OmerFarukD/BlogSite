using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Abstratcts;

public interface ICommentService
{
    ReturnModel<CommentResponseDto> GetById(Guid id);
    ReturnModel<List<CommentResponseDto>> GetAllByUserId(string userId);

    ReturnModel<List<CommentResponseDto>> GetAllByPostId(Guid postId);

    ReturnModel<NoData> Add(CommentAddRequestDto dto, string userId);

    ReturnModel<NoData> Delete(Guid id);

}
