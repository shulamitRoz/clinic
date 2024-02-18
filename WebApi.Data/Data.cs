using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace WebApi.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Doctors>doctors  { get; set; }   
        public DbSet<Patients> patients { get; set; }    
        public DbSet<Turn>turnes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;database=clinc");
        }

    }
}
