using Core.Entities;

namespace BlogSite.Models.Entities;

public sealed class Category : Entity<int>
{
    public string Name { get; set; }

    public List<Post> Posts { get; set; }

}
