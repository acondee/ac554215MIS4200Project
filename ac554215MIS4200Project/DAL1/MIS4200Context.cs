using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ac554215MIS4200Project.Models;
using System.Data.Entity;

namespace ac554215MIS4200Project.DAL1
{
    public class MIS4200Context : DbContext
    {
        public MIS4200Context() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MIS4200Context, ac554215MIS4200Project.Migrations.MISContext.Configuration>("DefaultConnection"));
        }
        public DbSet<student> students { get; set; }
        public DbSet<course> courses { get; set; }
        public DbSet<enrollment> enrollments { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}