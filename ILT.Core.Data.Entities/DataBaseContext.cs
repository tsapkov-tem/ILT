using Microsoft.EntityFrameworkCore;

namespace ILT.Core.Data.Entities
{
    public class DatabaseContext(DbContextOptions options) : DbContext(options)
    {

    }
}
