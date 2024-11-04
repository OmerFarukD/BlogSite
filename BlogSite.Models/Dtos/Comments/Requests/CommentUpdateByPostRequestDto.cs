namespace BlogSite.Models.Dtos.Comments.Requests
{
    public sealed record CommentUpdateByPostRequestDto(Guid Id, string Text, Guid PostId);
}
