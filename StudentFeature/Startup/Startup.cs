using EFORM.Models;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentFeature.CrudUsecase;
using StudentFeature.GetNotesForSubjectByStudentUseCase;
using StudentFeature.GetStudentByClassUseCase;
using StudentFeature.GetStudentsWithNotesOnSubjectCatalogUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeature.Startup
{
    public static class Startup
    {
        public static void AddStudentFeatures(this IServiceCollection service, string efConnectionString)
        {
            service.AddNuggets();
            service.AddEFDatabaseConnection(efConnectionString);
            service.CrudUseCase();
            service.GetNotesForSubjectByStudentUseCase();
            service.GetStudentsByClassUseCase();
            service.GetStudentsWithNotesOnSubjectCatalogUseCase();
        }
        public static void AddNuggets(this IServiceCollection service)
        {
            service.AddFluentValidation(options =>
            {
                options.ImplicitlyValidateChildProperties = true;
                options.ImplicitlyValidateRootCollectionElements = true;
                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
        public static void AddEFDatabaseConnection(this IServiceCollection service, string efConnectionString)
        {
            service.AddDbContext<CatalogHomeworkContext>(
                options => options.UseSqlServer(efConnectionString));
        }

        public static void GetStudentsWithNotesOnSubjectCatalogUseCase(this IServiceCollection service)
        {
            service.AddScoped<IGetStudentsWithNotesOnSubjectCatalog, GetStudentsWithNotesOnSubjectCatalog>();
            service.AddScoped<GetStudentsWithNotesOnSubjectCatalogUseCase.BusinessValidations.ICatalogIdValidation, GetStudentsWithNotesOnSubjectCatalogUseCase.BusinessValidations.CatalogIdValidation>();
            service.AddScoped<GetStudentsWithNotesOnSubjectCatalogUseCase.BusinessValidations.ISubjectIdValidation, GetStudentsWithNotesOnSubjectCatalogUseCase.BusinessValidations.SubjectIdValidation>();
        }

        public static void GetStudentsByClassUseCase(this IServiceCollection service)
        {
            service.AddScoped<IGetStudentsByClass, GetStudentsByClass>();
            service.AddScoped<GetStudentsByClassUseCase.BusinessValidations.IClasaValidation, GetStudentsByClassUseCase.BusinessValidations.ClasaValidation>();
        }
        public static void GetNotesForSubjectByStudentUseCase(this IServiceCollection service)
        {
            
            service.AddScoped<IGetNotesForSubjectByStudent, GetNotesForSubjectByStudent>();
            service.AddScoped<GetNotesForSubjectByStudentUseCase.BusinessValidations.IStudentIdValidation, GetNotesForSubjectByStudentUseCase.BusinessValidations.StudentIdValidation>();
        }

        public static void CrudUseCase(this IServiceCollection service)
        {
            service.AddScoped<IStudentService, StudentService>();
        }
    }
}
