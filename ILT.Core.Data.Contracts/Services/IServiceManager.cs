using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILT.Core.Data.Contracts.Services
{
    public interface IServiceManager
    {
        public IUserService UserService { get; }
        public IGroupService GroupService { get; }
    }
}
