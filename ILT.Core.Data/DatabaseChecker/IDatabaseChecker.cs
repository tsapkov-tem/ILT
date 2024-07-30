using Microsoft.Extensions.Configuration;

namespace ILT.Core.Data.DatabaseChecker
{
    public interface IDatabaseChecker
    {
        protected const int MAX_ATTEMPTS_TO_CONNECT = 10;
        protected const int RETRY_AFTER_MILLESECONDS = 5000;

        public bool IsDbOnline(IConfiguration configuration);
    }
}
