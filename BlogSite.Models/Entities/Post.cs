using Core.Entities;

namespace BlogSite.Models.Entities;

public sealed class Post : Entity<Guid>
{

    public string Title { get; set; }

    public string Content { get; set; }


}
