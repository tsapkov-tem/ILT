using ILT.Core.Data.Contracts.Services;
using ILT.Core.Data.Entities;
using ILT.Core.Data.Entities.Models;
using ILT.Core.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace ILT.Core.Data.Services
{
    public class GroupService : BaseService<Group>, IGroupService
    {
        public GroupService(DbContextOptions<DatabaseContext> dbContextOptions)
            : base(dbContextOptions, new GroupRepository(new DatabaseContext(dbContextOptions)))
        {
        }
    }
}
