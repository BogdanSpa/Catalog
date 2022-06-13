using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace StudentFeature.GetStudentsWithNotesOnSubjectCatalogUseCase
{
    public class GetStudentsWithNotesOnSubjectCatalogValidation : AbstractValidator<GetStudentsWithNotesOnSubjectCatalogRequest>
    {
        public GetStudentsWithNotesOnSubjectCatalogValidation()
        {
            RuleFor(s => s.SubjectID)
                .NotNull().WithMessage("Subject ID cannot be null")
                .NotEmpty().WithMessage("Subject ID cannot be empty")
                .GreaterThan(0).WithMessage("Subject ID must be greater than 0");

            RuleFor(c => c.CatalogID)
                .NotNull().WithMessage("Catalog ID cannot be null")
                .NotEmpty().WithMessage("Catalog ID cannot be empty")
                .GreaterThan(0).WithMessage("Catalog ID must be greater than 0");
        }
    }
}
