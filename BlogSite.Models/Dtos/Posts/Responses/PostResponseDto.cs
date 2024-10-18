using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Posts.Responses;

public sealed record PostResponseDto
{
    public Guid Id { get; init; }
    public  string Title { get; init; }
    public string Content { get; init; }
    public DateTime CreatedDate { get; init; }
    public string UserName { get; init; }
    public string Category { get; init; }
}
 
  

