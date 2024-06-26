﻿using Microsoft.AspNetCore.Http;
using ProjectInit.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Core.Entities.Projects
{
    public class Project : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Поле потрібно заповнити.")]
        [Display(Name = "Назва курсу")]
        [MinLength(5, ErrorMessage = "Мінімальна довжина поля 5 символів")]
        public string? CourseName { get; set; } = string.Empty;
        public string? ProjectName { get; set; } = string.Empty;
        public string? Groups { get; set; } = string.Empty;
        public string? ImagePath { get; set; } = "/img/projects/no_photo.jpg";
        public DateTime? TitleApproveDeadline { get; set; } = DateTime.Now.AddDays(1);
        public DateTime? FinishDeadline { get; set; } = DateTime.Now.AddDays(10);
        public bool IsActive { get; set; }
        public User? Teacher { get; set; }

        [ForeignKey(nameof(Teacher))]
        public Guid? TeacherId { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public virtual ICollection<ProjectItem> Items { get; set; } = new HashSet<ProjectItem>();
        public virtual ICollection<ProjectLink> Links { get; set; } = new HashSet<ProjectLink>();
    }
}
