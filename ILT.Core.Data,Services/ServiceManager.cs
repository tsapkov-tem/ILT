using ILT.Core.Data.Contracts.Services;
using ILT.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ILT.Core.Data.Services
{
    public class ServiceManager : IServiceManager
    {
        public IUserService UserService => new UserService(_dbContextOptions);
        public IGroupService GroupService => new GroupService(_dbContextOptions);

        private readonly DbContextOptions<DatabaseContext> _dbContextOptions;
        public ServiceManager(DbContextOptions<DatabaseContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }
    }
}
