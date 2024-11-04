using BlogSite.Models.Entities;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccess.Abstracts;

public interface ICommentRepository : IRepository<Comment, Guid>
{
}
