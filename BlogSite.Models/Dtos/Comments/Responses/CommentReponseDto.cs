using BlogSite.Models.Entities;

namespace BlogSite.Models.Dtos.Comments.Responses;

public sealed record CommentResponseDto 
{

    public string Text { get; init; }

    public string UserName { get; init; }

    public string PostTitle { get; init; }

}
