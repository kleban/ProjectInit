﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectInit.Core.Context;

#nullable disable

namespace ProjectInit.Core.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProjectInit.Core.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FinishDeadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Groups")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("TitleApproveDeadline")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = new Guid("69a4353b-99f5-4191-8ee1-8aa1be853441"),
                            CourseName = "Програмування на С№",
                            FinishDeadline = new DateTime(2024, 4, 18, 10, 3, 25, 247, DateTimeKind.Local).AddTicks(4784),
                            Groups = "ТГ-1, ТГ-2",
                            ImagePath = "/img/projects/no_photo.jpg",
                            IsActive = true,
                            ProjectName = "Колективний проєкт",
                            TeacherId = new Guid("815f4ee2-cfb5-4004-b309-ee3869d63769"),
                            TitleApproveDeadline = new DateTime(2024, 4, 8, 10, 3, 25, 247, DateTimeKind.Local).AddTicks(4779)
                        });
                });

            modelBuilder.Entity("ProjectInit.Core.Entities.ProjectAccessQuery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProjectItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProjectItemId");

                    b.HasIndex("UserId");

                    b.ToTable("AccessQueries");
                });

            modelBuilder.Entity("ProjectInit.Core.Entities.ProjectApproveQuery", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ProjectItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StudentComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherComment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProjectItemId");

                    b.ToTable("ApproveQueries");
                });

            modelBuilder.Entity("ProjectInit.Core.Entities.ProjectItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StatusDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StatusId");

                    b.ToTable("ProjectItems");
                });

            modelBuilder.Entity("ProjectInit.Core.Entities.ProjectItemStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectItemStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Чернетка"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Відхилено"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Затверджено"
                        });
                });

            modelBuilder.Entity("ProjectInit.Core.Entities.ProjectLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectLinks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e8edad47-dd29-424a-a26b-2c50987d6257"),
                            Name = "Курс у системі Moodle",
                            ProjectId = new Guid("69a4353b-99f5-4191-8ee1-8aa1be853441"),
                            Url = "https://moodle.oa.edu.ua/yo"
                        },
                        new
                        {
                            Id = new Guid("1c4470cb-b1b4-41c7-87c4-f6e44c051432"),
                            Name = "Деталізована інформація про проєкт (Notion)",
                            ProjectId = new Guid("69a4353b-99f5-4191-8ee1-8aa1be853441"),
                            Url = "https://notion.so/yo"
                        });
                });

            modelBuilder.Entity("ProjectInit.Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("815f4ee2-cfb5-4004-b309-ee3869d63769"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d92aa179-0746-448d-8c6d-666028427d4a",
                            Email = "admin@projects.kleban.page",
                            EmailConfirmed = true,
                            FullName = "Юрій Клебан",
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN@PROJECTS.KLEBAN.PAGE",
                            PasswordHash = "AQAAAAIAAYagAAAAEA9360r1IYw3eVIMAwtI3/9INB5CXzBI+Mbale/HdlsUXBE+PMuQGbU/o8iUFYl+0w==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "admin@projects.kleban.page"
                        },
                        new
                        {
                            Id = new Guid("4383c17e-c75b-445c-baa2-d16f24debb7c"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "eefcde0b-ec41-4cf6-9acc-1aebb2372f0e",
                            Email = "teacher@projects.kleban.page",
                            EmailConfirmed = true,
                            FullName = "Іван Петренко",
                            LockoutEnabled = false,
                            NormalizedUserName = "TEACHER@PROJECTS.KLEBAN.PAGE",
                            PasswordHash = "AQAAAAIAAYagAAAAEJbnd+G2vc/2h625AIsm49gqljpKa56H73htHnFMwf9Z4H9sGYP9e25ngyyrqrN0ag==",
                            PhoneNumberConfirmed = false,
                            TwoFactorEnabled = false,
                            UserName = "teacher@projects.kleban.page"
                        });
                });

            modelBuilder.Entity("ProjectItemUser", b =>
                {
                    b.Property<Guid>("StudentProjectsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("StudentProjectsId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("ProjectItemUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("ProjectInit.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("ProjectInit.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectInit.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("ProjectInit.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectInit.Core.Entities.Project", b =>
                {
                    b.HasOne("ProjectInit.Core.Entities.User", "Teacher")
                        .WithMany("TeacherProjects")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ProjectInit.Core.Entities.ProjectAccessQuery", b =>
                {
                    b.HasOne("ProjectInit.Core.Entities.ProjectItem", "ProjectItem")
                        .WithMany("AccessQueries")
                        .HasForeignKey("ProjectItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectInit.Core.Entities.User", "Student")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectItem");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ProjectInit.Core.Entities.ProjectApproveQuery", b =>
                {
                    b.HasOne("ProjectInit.Core.Entities.ProjectItem", "ProjectItem")
                        .WithMany("ApproveQueries")
                        .HasForeignKey("ProjectItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProjectItem");
                });

            modelBuilder.Entity("ProjectInit.Core.Entities.ProjectItem", b =>
                {
                    b.HasOne("ProjectInit.Core.Entities.Project", "Project")
                        .WithMany("Items")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectInit.Core.Entities.ProjectItemStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("ProjectInit.Core.Entities.ProjectLink", b =>
                {
                    b.HasOne("ProjectInit.Core.Entities.Project", "Project")
                        .WithMany("Links")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ProjectItemUser", b =>
                {
                    b.HasOne("ProjectInit.Core.Entities.ProjectItem", null)
                        .WithMany()
                        .HasForeignKey("StudentProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectInit.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectInit.Core.Entities.Project", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Links");
                });

            modelBuilder.Entity("ProjectInit.Core.Entities.ProjectItem", b =>
                {
                    b.Navigation("AccessQueries");

                    b.Navigation("ApproveQueries");
                });

            modelBuilder.Entity("ProjectInit.Core.Entities.User", b =>
                {
                    b.Navigation("TeacherProjects");
                });
#pragma warning restore 612, 618
        }
    }
}
