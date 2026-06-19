using GymApp.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GymApp.Filters;

// Step 1: create a public class called SoftDeleteInterceptor that implements IAsyncActionFilter
public class SoftDeleteInterceptor : IAsyncActionFilter
{
    // Step 2: declare a private readonly field of type AppDbContext called _db
    private readonly GymDbContext _db = default!;

    // Step 3: create a constructor that takes AppDbContext as a parameter and assigns it to _db
    public SoftDeleteInterceptor(GymDbContext db) => _db = db;

    // Step 4: implement the OnActionExecutionAsync method with ActionExecutingContext and ActionExecutionDelegate parameters
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context, 
        ActionExecutionDelegate next)
    {

        // Step 5: read the action name from the route values
        var action = context.ActionDescriptor.RouteValues["action"];

        // Step 6: check if the action name is "Delete"
        if(action == "Delete")
        {
            // Step 7: get the "id" argument from the action arguments and convert it to a string
            var id = context.ActionArguments["id"]?.ToString();

            // step 8: check if id exists or not
            if(id is not null)
            {
                // Step 9: query the database to find the entity by the parsed id

                var entity = await _db.Plans.FindAsync(int.Parse(id));

                // Step 10: set IsDeleted to true on the entity
                entity!.IsDeleted = true;

                // Step 11: set DeletedAt to the current UTC time
                entity!.DeletedAt = DateTime.UtcNow;

                // Step 12: save the changes to the database
                await _db.SaveChangesAsync();

                // Step 13: set context.Result to a JsonResult with a success message
                context.Result = new JsonResult(new
                {
                    message = "Plan is soft deleted successfully"
                });

                // Step 14: return early to short-circuit (never calling next)
                return;
            }
        }

        // Step 15: call next() to let all non-Delete requests pass through normally
        await next();
    
    }
}
