using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_P201.EFCore
{
    internal class EfContext : DbContext
    {
        internal DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
            Data Source=(LocalDB)\MSSQLLocalDB;
            Initial Catalog=ef201ado;
            Integrated Security=True");
        }
    }
}
