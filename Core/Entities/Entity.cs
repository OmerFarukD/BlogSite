

namespace Core.Entities;

public abstract class Entity<TPrimaryKey>
{

    public TPrimaryKey Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
