namespace BlogSite.Models.Dtos.Posts.Requests;

public sealed record UpdatePostRequest(Guid id,string Title, string Content);

