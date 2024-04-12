using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectInit.Core.Entities;
using ProjectInit.Core.Entities.Common;
using ProjectInit.Core.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Core.Context
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            var (arID, trID, srID) = _seedRoles(builder);
            
            var teacherId = _seedTeachers(builder, trID, arID);
            var projectId = _seedProject(builder, teacherId);
            
            _seedProjectItemStatuses(builder);
            _seedProjectLinks(builder, projectId);
            
        }

        private static (Guid, Guid, Guid) _seedRoles(ModelBuilder builder)
        {
            var ADMIN_ROLE_ID = Guid.NewGuid();
            var TEACHER_ROLE_ID = Guid.NewGuid();
            var STUDENT_ROLE_ID = Guid.NewGuid();

            builder.Entity<IdentityRole<Guid>>()
               .HasData(
                   new IdentityRole<Guid>
                   {
                       Id = ADMIN_ROLE_ID,
                       Name = "Admin",
                       NormalizedName = "ADMIN",
                       ConcurrencyStamp = ADMIN_ROLE_ID.ToString()
                   },
                   new IdentityRole<Guid>
                   {
                       Id = TEACHER_ROLE_ID,
                       Name = "Teacher",
                       NormalizedName = "TEACHER",
                       ConcurrencyStamp = TEACHER_ROLE_ID.ToString()
                   },
                   new IdentityRole<Guid>
                   {
                       Id = STUDENT_ROLE_ID,
                       Name = "Student",
                       NormalizedName = "STUDENT",
                       ConcurrencyStamp = STUDENT_ROLE_ID.ToString()
                   }
               );


            return (ADMIN_ROLE_ID, TEACHER_ROLE_ID, STUDENT_ROLE_ID);

        }

        private static Guid _seedTeachers(ModelBuilder builder, Guid TEACHER_ROLE_ID, Guid ADMIN_ROLE_ID)
        {
            var teacherId = Guid.NewGuid();

            var teacher = new User
            {
                Id = teacherId,
                UserName = "admin@projects.kleban.page",
                EmailConfirmed = true,
                NormalizedUserName = "admin@projects.kleban.page".ToUpper(),
                Email = "admin@projects.kleban.page",
                NormalizedEmail = "admin@projects.kleban.page".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Юрій Клебан"
            };

            var teacher2 = new User
            {
                Id = Guid.NewGuid(),
                UserName = "teacher@projects.kleban.page",
                EmailConfirmed = true,
                NormalizedUserName = "teacher@projects.kleban.page".ToUpper(),
                Email = "teacher@projects.kleban.page",
                NormalizedEmail = "teacher@projects.kleban.page".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                FullName = "Іван Петренко"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            teacher.PasswordHash = passwordHasher.HashPassword(teacher, "Pr0#et1n1t");
            teacher2.PasswordHash = passwordHasher.HashPassword(teacher2, "Pr0#et1n1t");

            builder.Entity<User>()
                .HasData(teacher, teacher2);

            builder.Entity<IdentityUserRole<Guid>>()
              .HasData(
                  new IdentityUserRole<Guid>
                  {
                      RoleId = ADMIN_ROLE_ID,
                      UserId = teacherId
                  },
                  new IdentityUserRole<Guid>
                  {
                      RoleId = TEACHER_ROLE_ID,
                      UserId = teacherId
                  }
              );

            return teacherId;
        }

        static void _seedProjectItems(ModelBuilder builder, Guid projectId)
        {
            builder.Entity<ProjectItem>().HasData(new List<ProjectItem> { 
            new ProjectItem
            {
                Description = "Lorem Ipsum - це текст-\"риба\", що використовується в друкарстві та дизайні. Lorem Ipsum є, фактично, стандартною \"рибою\" аж з XVI сторіччя, коли невідомий друкар взяв шрифтову гранку та склав на ній підбірку зразків шрифтів. \"Риба\" не тільки успішно пережила п'ять століть, але й прижилася в електронному верстуванні, залишаючись по суті незмінною. Вона популяризувалась в 60-их роках минулого сторіччя завдяки виданню зразків шрифтів Letraset, які містили уривки з Lorem Ipsum, і вдруге - нещодавно завдяки програмам комп'ютерного верстування на кшталт Aldus Pagemaker, які використовували різні версії Lorem Ipsum.",
                ProjectId = projectId,
                StatusId = 1,
                Title = "Тестова тема проєкту №1"
            },
            new ProjectItem
            {
                Description = "Lorem Ipsum - це текст-\"риба\", що використовується в друкарстві та дизайні. Lorem Ipsum є, фактично, стандартною \"рибою\" аж з XVI сторіччя, коли невідомий друкар взяв шрифтову гранку та склав на ній підбірку зразків шрифтів. \"Риба\" не тільки успішно пережила п'ять століть, але й прижилася в електронному верстуванні, залишаючись по суті незмінною. Вона популяризувалась в 60-их роках минулого сторіччя завдяки виданню зразків шрифтів Letraset, які містили уривки з Lorem Ipsum, і вдруге - нещодавно завдяки програмам комп'ютерного верстування на кшталт Aldus Pagemaker, які використовували різні версії Lorem Ipsum.",
                ProjectId = projectId,
                StatusId = 2,
                Title = "Тестова тема проєкту №2"
            }
            });
        }
        static Guid _seedProject(ModelBuilder builder, Guid teacherId)
        {
            var projectId = Guid.NewGuid();

            builder.Entity<Project>().HasData(new List<Project>
            {
                new Project
                {
                    Id = projectId,
                    CourseName = "Програмування на С№",
                    Groups = "ТГ-1, ТГ-2",
                    IsActive = true,
                    TeacherId = teacherId,
                    ProjectName = "Колективний проєкт",
                    TitleApproveDeadline = DateTime.Now.AddDays(10),
                    FinishDeadline = DateTime.Now.AddDays(20)
                }
            });

            return projectId;
        }
        static void _seedProjectItemStatuses(ModelBuilder builder)
        {
            builder.Entity<ProjectItemStatus>().HasData(
                new List<ProjectItemStatus> { new ProjectItemStatus
                {
                    Id = (int)StatusType.Draft,
                    Title = "Чернетка"
                },
                new ProjectItemStatus
                {
                    Id = (int)StatusType.Rejected,
                    Title = "Відхилено"
                },
                new ProjectItemStatus
                {
                    Id = (int)StatusType.Approved,
                    Title = "Затверджено"
                }});
        }
        static void _seedProjectLinks(ModelBuilder builder, Guid projectId)
        {
            builder.Entity<ProjectLink>().HasData(
                new List<ProjectLink> {
                    new ProjectLink
                    {
                        ProjectId = projectId,
                        Name = "Курс у системі Moodle",
                        Url = "https://moodle.oa.edu.ua/yo"
                    },
                new ProjectLink
                    {
                        ProjectId = projectId,
                        Name = "Деталізована інформація про проєкт (Notion)",
                        Url = "https://notion.so/yo"
                    }});
        }
    }
}
