using ILT.Core.Data.Entities;
using ILT.Core.Data.Entities.Models;
using ILT.Core.Data.Contracts.Services;
using Microsoft.EntityFrameworkCore;
using ILT.Core.Data.Repository;

namespace ILT.Core.Data.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(DbContextOptions<DatabaseContext> dbContextOptions)
            : base(dbContextOptions, new UserRepository(new DatabaseContext(dbContextOptions)))
        {
        }
    }
}
