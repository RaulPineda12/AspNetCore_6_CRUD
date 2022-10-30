using AspNetCore_6_MVC_Crud.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore_6_MVC_Crud.Data
{
    public class DataContext: DbContext 
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
