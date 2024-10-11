using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Entities;
using Core.Repositories;

namespace BlogSite.DataAccess.Concretes;

public class EfPostRepository : EfRepositoryBase<BaseDbContext, Post, Guid>,IPostRepository
{
    public EfPostRepository(BaseDbContext context) : base(context)
    {
    }
}
