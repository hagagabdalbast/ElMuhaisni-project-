using ElMuhaisni.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElMuhaisni.DAL.Context
{
    public class ElMuhaisniContext : IdentityDbContext<ApplicationUser>
    {
        public ElMuhaisniContext(DbContextOptions<ElMuhaisniContext> options) : base(options)
        { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<LastNew> LastNews { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
       // public DbSet<LastNew> LastNews { get; set; }
        //public DbSet<Attachment> Attachments { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Attachment>()
        //        .HasOne(a => a.LastNew)
        //        .WithMany(l => l.Attachments)
        //        .HasForeignKey(a => a.LastNewId)
        //        .OnDelete(DeleteBehavior.Cascade); // Ensure correct delete behavior

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
