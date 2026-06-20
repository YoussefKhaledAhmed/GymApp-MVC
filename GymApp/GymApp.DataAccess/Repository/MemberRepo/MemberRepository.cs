using GymApp.DataAccess.Data.Contexts;
using GymApp.DataAccess.Entities;
using GymApp.DataAccess.Repository.GenericRepo;

namespace GymApp.DataAccess.Repository.MemberRepo;

public class MemberRepository(GymDbContext dbContext) : Repository<Member>(dbContext) , IMemberRepository 
{
}
