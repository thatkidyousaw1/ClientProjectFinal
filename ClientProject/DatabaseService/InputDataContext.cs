using ClientProject.Model;
using System;
using System.Collections.Generic;
//using System.Data.Entity.ModelConfiguration.Conventions;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Microsoft.EntityFrameworkCore;


namespace ClientProject.DatabaseService
{
    public class InputDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = clientdatabase.db");
        }

        public DbSet<UserData> UserData { get; set; }
    }
}
