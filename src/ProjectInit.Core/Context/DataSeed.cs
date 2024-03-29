using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectInit.Core.Entities;
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
            var teacherId = _seedTeachers(builder);
            var projectId = _seedProject(builder, teacherId);
            
            _seedProjectItemStatuses(builder);
            _seedProjectLinks(builder, projectId);
            
        }

        private static Guid _seedTeachers(ModelBuilder builder)
        {
            var teacherId = Guid.NewGuid();

            var teacher = new User
            {
                Id = teacherId,
                UserName = "admin@projects.kleban.page",
                EmailConfirmed = true,
                NormalizedUserName = "admin@projects.kleban.page".ToUpper(),
                Email = "admin@projects.kleban.page",
                FullName = "Юрій Клебан"
            };

            var teacher2 = new User
            {
                Id = Guid.NewGuid(),
                UserName = "teacher@projects.kleban.page",
                EmailConfirmed = true,
                NormalizedUserName = "teacher@projects.kleban.page".ToUpper(),
                Email = "teacher@projects.kleban.page",
                FullName = "Іван Петренко"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            teacher.PasswordHash = passwordHasher.HashPassword(teacher, "Pr0#et1n1t");
            teacher2.PasswordHash = passwordHasher.HashPassword(teacher2, "Pr0#et1n1t");

            builder.Entity<User>()
                .HasData(teacher, teacher2);

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
