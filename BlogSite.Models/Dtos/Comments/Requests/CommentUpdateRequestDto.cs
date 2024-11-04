namespace BlogSite.Models.Dtos.Comments.Requests
{
    public sealed record CommentUpdateRequestDto(Guid Id, string Text);
}
