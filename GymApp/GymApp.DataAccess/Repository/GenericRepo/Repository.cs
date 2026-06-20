using GymApp.DataAccess.Data.Contexts;
using GymApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GymApp.DataAccess.Repository.GenericRepo;

public class Repository<TEntity>(GymDbContext dbContext) : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly GymDbContext _dbContext = dbContext;
    private readonly DbSet<TEntity> _dbSet = dbContext.Set<TEntity>();


    public async Task<List<TEntity>> GetAllAsync(string[]? includes = null , CancellationToken cancellationToken = default)
    {
        var query = _dbSet.AsQueryable();

        if(includes is not null)
        {
            foreach (var include in includes)
            {
                var exists = typeof(TEntity)
                    .GetProperties()
                    .Any(p => p.Name.Equals(include, StringComparison.OrdinalIgnoreCase));

                if (exists)
                {
                    query = query.Include(include);
                }
            }
        }

        return await query.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        => await _dbSet.FirstOrDefaultAsync(e => e.Id == id , cancellationToken);

    public async Task<TEntity?> GetByIdIncludingDeletedAsync(int id, CancellationToken cancellationToken = default)
        => await _dbSet.IgnoreQueryFilters().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

    public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => await _dbSet.AnyAsync(predicate , cancellationToken);


    public async Task<IReadOnlyList<TEntity>?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        => await _dbSet.Where(predicate).ToListAsync(cancellationToken);


    public async Task Add(TEntity entity , CancellationToken cancellationToken)
        => await _dbSet.AddAsync(entity , cancellationToken);
    public void Update(TEntity entity)
        => _dbSet.Update(entity);
    public Task SoftDelete(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.IsDeleted = true;
        _dbSet.Update(entity);
        return Task.CompletedTask;
    }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _dbContext.SaveChangesAsync(cancellationToken);


}
