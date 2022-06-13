using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace GradesFeature.AddNoteForStudentUseCase
{
    public class AddNoteForStudentValidation : AbstractValidator<AddNoteForStudentModel>
    {
        public AddNoteForStudentValidation()
        {
            RuleFor(n => n.MaterieId)
                .NotNull().WithMessage("Subject ID cannot be null")
                .NotEmpty().WithMessage("Subject ID cannot be empty")
                .GreaterThan(0).WithMessage("Subject ID cannot be 0");

            RuleFor(n => n.StudentId)
                .NotNull().WithMessage("Student ID cannot be null")
                .NotEmpty().WithMessage("Student ID cannot be empty")
                .GreaterThan(0).WithMessage("Student ID cannot be 0");

            RuleFor(n => n.CatalogId)
                .NotNull().WithMessage("Catalog ID cannot be null")
                .NotEmpty().WithMessage("Catalog ID cannot be empty")
                .GreaterThan(0).WithMessage("Catalog ID cannot be 0");

            RuleFor(n => n.Note)
                .NotNull().WithMessage("Student ID cannot be null")
                .NotEmpty().WithMessage("Student ID cannot be empty");
                //.GreaterThan(0).WithMessage("Student ID cannot be 0");
                //.LessThan(10).WithMessage()
        }
    }
}
