using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Comments.Requests
{
    public sealed record CommentAddRequestDto(string Text, Guid PostId);
}
