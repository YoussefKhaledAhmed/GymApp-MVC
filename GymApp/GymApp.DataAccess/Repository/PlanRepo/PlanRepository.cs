using GymApp.DataAccess.Data.Contexts;
using GymApp.DataAccess.Entities;
using GymApp.DataAccess.Repository.GenericRepo;
using Microsoft.EntityFrameworkCore;

namespace GymApp.DataAccess.Repository.PlanRepo;

public class PlanRepository(GymDbContext dbContext) : Repository<Plan>(dbContext) , IPlanRepository
{
    
}
