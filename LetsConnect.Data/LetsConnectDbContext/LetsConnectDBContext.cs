using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LetsConnect.Models;
using LetsConnect.Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace LetsConnect.DBContext
{
    public class LetsConnectDBContext:DbContext
    {
        public LetsConnectDBContext(DbContextOptions<LetsConnectDBContext> options) : base(options)
        {
            //this.Configuration.LazyLoadingEnabled = false;

        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Technologies> Technologies { get; set; }
        public DbSet<UserTechnologies> UserTechnologies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Experience>().HasData(
                new Experience
                {
                    ExperienceID = 1
                }
            );
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    RoleID = 1
                }
            );
            modelBuilder.Entity<Technologies>().HasData(
                new Technologies
                {
                    TechnologyID = 1
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    FirstName = "Kundan",
                    LastName = "Prasad",
                    Email = "kundan@gmail.com",
                    Password = "welcome",
                    ExperienceID = 1,
                    RoleID = 1
                }
            );
            modelBuilder.Entity<UserTechnologies>().HasData(
                new UserTechnologies
                {
                    UserID = 1,
                    TechnologyID = 1

                }
            );

            modelBuilder.Entity<UserTechnologies>()
                    .HasKey(x => new { x.UserID, x.TechnologyID });

            modelBuilder.Entity<UserTechnologies>()
                .HasOne(x => x.User)
                .WithMany(y => y.UserTechnology)
                .HasForeignKey(x => x.UserID);

            modelBuilder.Entity<UserTechnologies>()
                .HasOne(x => x.Technology)
                .WithMany(y => y.UserTechnology)
                .HasForeignKey(x => x.TechnologyID);

            base.OnModelCreating(modelBuilder);
        }

    }
}