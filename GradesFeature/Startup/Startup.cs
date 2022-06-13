using EFORM.Models;
using FluentValidation.AspNetCore;
using GradesFeature.AddNoteForStudentUseCase;
using GradesFeature.CrudUsecase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GradesFeature.Startup
{
    public static class Startup
    {
        public static void AddGradesFeatures(this IServiceCollection service, string efConnectionString)
        {
            service.AddNuggets();
            service.AddEFDatabaseConnection(efConnectionString);
            service.AddNotesForStudentUseCase();
            service.CrudUseCase();
        }

        public static void AddEFDatabaseConnection(this IServiceCollection service, string efConnectionString)
        {
            service.AddDbContext<CatalogHomeworkContext>(
                options => options.UseSqlServer(efConnectionString));
        }

        public static void AddNuggets(this IServiceCollection service)
        {
            service.AddFluentValidation(options =>
            {
                options.ImplicitlyValidateChildProperties = true;
                options.ImplicitlyValidateRootCollectionElements = true;
                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });
            service.AddAutoMapper(typeof(AddNoteForStudentMapping));
        }
        public static void AddNotesForStudentUseCase(this IServiceCollection service)
        {
            service.AddScoped<IAddNoteForStudent, AddNoteForStudent>();
            service.AddScoped<AddNoteForStudentUseCase.Commands.IInsertNoteForStudent, AddNoteForStudentUseCase.Commands.InsertNoteForStudent>();
            service.AddScoped<AddNoteForStudentUseCase.BusinessValidation.ICatalogIdValidation, AddNoteForStudentUseCase.BusinessValidation.CatalogIdValidation>();
            service.AddScoped<AddNoteForStudentUseCase.BusinessValidation.ISubjectIdValidation, AddNoteForStudentUseCase.BusinessValidation.SubjectIdValidation>();
            service.AddScoped<AddNoteForStudentUseCase.BusinessValidation.IStudentIdValidation, AddNoteForStudentUseCase.BusinessValidation.StudentIdValidation>();
        }

        public static void CrudUseCase(this IServiceCollection service)
        {
            service.AddScoped<INoteService, NoteService>();
        }
    }
}
