using Microsoft.Extensions.Configuration;

namespace ILT.Core.Data.Initialization
{
    public interface IDatabaseInitializer
    {
        public void InitializeDatabase(IConfiguration configuration);
    }
}
