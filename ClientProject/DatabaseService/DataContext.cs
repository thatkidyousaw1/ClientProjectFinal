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
using System.Windows;

namespace ClientProject.DatabaseService
{
    public class DataContext : DbContext
    {
        //public DataContext() : base(new SQLiteConnection()
        //{
        //    ConnectionString = new SQLiteConnectionStringBuilder()
        //    {
        //        DataSource = "clientdatabase.db",
        //        ForeignKeys = false
        //    }.ConnectionString
        //}, true)
        //{ }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    base.OnModelCreating(modelBuilder);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = clientdatabase.db");

            //optionsBuilder.UseSqlite("@:URI=file:" + Application.StartupPath + "\\clientdatabase.db";
        }

        public DbSet<User> Users { get; set; }
    }
}
