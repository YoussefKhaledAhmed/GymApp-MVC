using GymApp.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GymApp.DataAccess.Filters;

// Step 1: create a public class called SoftDeleteInterceptor that inherits from SaveChangesInterceptor
public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    // Step 2: override SavingChanges for synchronous save operations
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        // Step 3: apply soft delete logic before saving
        ApplySoftDelete(eventData.Context);
        return base.SavingChanges(eventData, result);
    }

    // Step 4: override SavingChangesAsync for asynchronous save operations
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        // Step 5: apply soft delete logic before saving asynchronously
        ApplySoftDelete(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    // Step 6: create a private static method called ApplySoftDelete that takes a DbContext parameter
    private static void ApplySoftDelete(DbContext? context)
    {
        // Step 7: check if context is null and return early if so
        if (context is null) return;

        // Step 8: loop through all tracked entries in the ChangeTracker
        foreach (var entry in context.ChangeTracker.Entries())
        {
            // Step 9: check if the entry state is Deleted and the entity implements ISoftDeletable
            if (entry.State == EntityState.Deleted
                && entry.Entity is ISoftDeletable entity)
            {
                // Step 10: change the state to Modified so EF does an UPDATE not a DELETE
                entry.State = EntityState.Modified;
                // Step 11: set IsDeleted to true on the entity
                entity.IsDeleted = true;
                // Step 12: set DeletedAt to the current UTC time
                entity.DeletedAt = DateTime.UtcNow;
            }
        }
    }
}