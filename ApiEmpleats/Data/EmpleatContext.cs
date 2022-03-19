using Microsoft.EntityFrameworkCore;
using ApiEmpleats.Models;

namespace ApiEmpleats.Data
{
    public class EmpleatContext : DbContext
    {
        public EmpleatContext(DbContextOptions<EmpleatContext> options)
            : base(options)
        {
        }

        public DbSet<EmpleatInfo> EmpleatsInfo { get; set; }
    }
}