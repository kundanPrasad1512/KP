﻿// <auto-generated />
using System;
using LetsConnect.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LetsConnect.Data.Migrations
{
    [DbContext(typeof(LetsConnectDBContext))]
    partial class LetsConnectDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LetsConnect.Entities.Models.UserTechnologies", b =>
                {
                    b.Property<int>("UserID");

                    b.Property<int>("TechnologyID");

                    b.Property<int>("ID");

                    b.HasKey("UserID", "TechnologyID");

                    b.HasAlternateKey("ID");

                    b.HasIndex("TechnologyID");

                    b.ToTable("UserTechnologies");

                    b.HasData(
                        new { UserID = 1, TechnologyID = 1, ID = 0 }
                    );
                });

            modelBuilder.Entity("LetsConnect.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExperienceRange");

                    b.HasKey("ExperienceID");

                    b.ToTable("Experience");

                    b.HasData(
                        new { ExperienceID = 1 }
                    );
                });

            modelBuilder.Entity("LetsConnect.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName");

                    b.HasKey("RoleID");

                    b.ToTable("Role");

                    b.HasData(
                        new { RoleID = 1 }
                    );
                });

            modelBuilder.Entity("LetsConnect.Models.Technologies", b =>
                {
                    b.Property<int>("TechnologyID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TechnologyName");

                    b.HasKey("TechnologyID");

                    b.ToTable("Technologies");

                    b.HasData(
                        new { TechnologyID = 1 }
                    );
                });

            modelBuilder.Entity("LetsConnect.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email");

                    b.Property<int>("ExperienceID");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsActiveForJob");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNo");

                    b.Property<int>("RoleID");

                    b.HasKey("UserID");

                    b.HasIndex("ExperienceID");

                    b.HasIndex("RoleID");

                    b.ToTable("User");

                    b.HasData(
                        new { UserID = 1, CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Email = "kundan@gmail.com", ExperienceID = 1, FirstName = "Kundan", IsActive = false, IsActiveForJob = false, IsDeleted = false, LastName = "Prasad", ModifiedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), Password = "welcome", RoleID = 1 }
                    );
                });

            modelBuilder.Entity("LetsConnect.Entities.Models.UserTechnologies", b =>
                {
                    b.HasOne("LetsConnect.Models.Technologies", "Technology")
                        .WithMany("UserTechnology")
                        .HasForeignKey("TechnologyID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LetsConnect.Models.User", "User")
                        .WithMany("UserTechnology")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LetsConnect.Models.User", b =>
                {
                    b.HasOne("LetsConnect.Models.Experience", "Experience")
                        .WithMany("User")
                        .HasForeignKey("ExperienceID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LetsConnect.Models.Role", "Roles")
                        .WithMany("User")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
