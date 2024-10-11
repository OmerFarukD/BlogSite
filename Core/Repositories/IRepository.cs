using Core.Entities;

namespace Core.Repositories;

public interface IRepository<TEntiy,TId> where TEntiy : Entity<TId>, new()
{
    List<TEntiy> GetAll();
    TEntiy? GetById(TId id);

    TEntiy? Update(TEntiy entity);

    TEntiy? Add(TEntiy entity);

    TEntiy? Remove(TEntiy entity);
}
