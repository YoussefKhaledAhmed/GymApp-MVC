using GymApp.DataAccess.Entities;
using System.Linq.Expressions;

namespace GymApp.DataAccess.Repository.GenericRepo;

public interface IRepository <TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAllAsync(string[]? includes = null, CancellationToken cancellationToken = default);

    Task<TEntity?> GetByIdAsync(int id , CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdIncludingDeletedAsync(int id , CancellationToken cancellationToken = default);

    Task<IReadOnlyList<TEntity>?> FindAsync(Expression<Func<TEntity, bool>>predicate , CancellationToken cancellationToken = default);
    Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default); 

    Task Add(TEntity entity, CancellationToken cancellationToken);

    void Update(TEntity entity);

    Task SoftDelete(TEntity entity, CancellationToken cancellationToken = default);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
