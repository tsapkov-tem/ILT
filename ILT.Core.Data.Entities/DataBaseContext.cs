using ILT.Core.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ILT.Core.Data.Entities
{
    public class DataBaseContext(DbContextOptions options) : DbContext(options)
    {

    }
}
