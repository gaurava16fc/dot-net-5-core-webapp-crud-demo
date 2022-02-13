using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet5CoreWebApp.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) 
            : base(options)
        {
        }

        public DbSet<Employee> tblEmployee { get; set; }
        public DbSet<Departments> tblDepartment { get; set; }
    }
}
