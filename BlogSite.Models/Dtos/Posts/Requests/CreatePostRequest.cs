using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Posts.Requests;

public sealed record CreatePostRequest(string Title, string Content, int CategoryId);

