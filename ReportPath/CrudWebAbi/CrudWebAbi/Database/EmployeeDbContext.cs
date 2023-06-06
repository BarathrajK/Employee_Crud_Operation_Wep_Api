using CrudWebAbi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudWebAbi.Database
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
