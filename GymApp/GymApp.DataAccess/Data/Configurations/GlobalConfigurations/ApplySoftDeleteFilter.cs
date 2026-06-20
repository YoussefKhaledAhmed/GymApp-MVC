using GymApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GymApp.DataAccess.Data.Configurations.GlobalConfigurations;

public static class GlobalQueryFilters
{
    public static void ApplySoftDeleteFilter(ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entity.ClrType))
            {
                var parameter = Expression.Parameter(entity.ClrType, "e");
                var property = Expression.Property(parameter, "IsDeleted");
                var condition = Expression.Equal(property, Expression.Constant(false));
                var lambda = Expression.Lambda(condition, parameter);

                entity.SetQueryFilter(lambda);
            }
        }
    }
}
