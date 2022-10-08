using Batch17_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batch17_WebApp.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<SalaryModel> Salaries { get; set; }
    }
}
