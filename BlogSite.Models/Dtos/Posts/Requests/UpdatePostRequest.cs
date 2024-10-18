namespace BlogSite.Models.Dtos.Posts.Requests;

public sealed record UpdatePostRequest(Guid Id,string Title, string Content);

