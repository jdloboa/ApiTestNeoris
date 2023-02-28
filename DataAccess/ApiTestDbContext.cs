using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApiTestDbContext : DbContext
    {
        public ApiTestDbContext() 
        {

        }
        public ApiTestDbContext(DbContextOptions<ApiTestDbContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Movimiento> Movimiento { get; set; }

       
    }
}