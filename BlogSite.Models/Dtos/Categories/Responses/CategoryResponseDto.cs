namespace BlogSite.Models.Dtos.Categories.Responses;

public sealed record CategoryResponseDto
{
    public int Id { get; init; }

    public string Name { get; init; }
}
