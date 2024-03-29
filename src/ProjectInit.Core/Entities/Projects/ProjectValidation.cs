using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInit.Core.Entities.Projects
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(x => x.CourseName)
                .NotEmpty().WithMessage("Поле Назва курсу обов'язкове")
                .MinimumLength(5).WithMessage("Мінімальна довжина поля 5 символів");

            RuleFor(x => x.ProjectName)
                .NotEmpty().WithMessage("Поле Назва проєкту обов'язкове")
                .MinimumLength(5).WithMessage("Мінімальна довжина поля 5 символів");

            RuleFor(x => x.Groups).NotEmpty().WithMessage("Поле Групи обов'язкове");
        }
    }
}
