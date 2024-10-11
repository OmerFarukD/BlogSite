using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Posts.Responses;

public sealed record PostResponseDto(
    Guid Id,
    string Title,
    string Content,
    DateTime CreatedDate
    );

