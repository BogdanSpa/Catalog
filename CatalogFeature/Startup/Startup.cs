
using CatalogFeature.CrudUsecase;
using CatalogFeature.GetAverageForEachSubjectUsecase;
using CatalogFeature.GetNotesForCatalogUsecase;
using CatalogFeature.GetNotesForSubjectByStudentUseCase;
using CatalogFeature.GetStudentsByCatalogUseCase;
using CatalogFeature.GetSubjectsForCatalogUseCase;
using EFORM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogFeature.Startup
{
    public static class Startup
    {
        public static void AddCatalogFeatures(this IServiceCollection service, string efConnectionString)
        {
            service.AddEFDatabaseConnection(efConnectionString);
            service.CrudUseCase();
            service.GetAverageForEachSubjectUseCase();
            service.GetNotesForCatalogUseCase();
            service.GetNotesForSubjectByStudentUseCase();
            service.GetStudentsByCatalogUseCase();
            service.GetSubjectsForCatalogUseCase();
            service.AddNuggets();
        }

        public static void AddEFDatabaseConnection(this IServiceCollection service, string efConnectionString)
        {
            service.AddDbContext<CatalogHomeworkContext>(
                options => options.UseSqlServer(efConnectionString));
        }

        public static void CrudUseCase(this IServiceCollection service)
        {
            service.AddScoped<ICatalogService, CatalogService>();
        }

        public static void GetAverageForEachSubjectUseCase(this IServiceCollection service)
        {
            service.AddScoped<IGetAverageForEachSubject, GetAverageForEachSubject>();
            service.AddScoped<GetAverageForEachSubjectUsecase.BusinessValidations.ICatalogIdValidation, GetAverageForEachSubjectUsecase.BusinessValidations.CatalogIdValidation>();
        }

        public static void GetNotesForCatalogUseCase(this IServiceCollection service)
        {
            service.AddScoped<IGetNotesForCatalog, GetNotesForCatalog>();
            service.AddScoped<GetNotesForCatalogUsecase.BusinessValidations.ICatalogIdValidation, GetNotesForCatalogUsecase.BusinessValidations.CatalogIdValidation>();
        }

        public static void GetNotesForSubjectByStudentUseCase(this IServiceCollection service)
        {
            service.AddScoped<IGetNotesForSubjectByStudent, GetNotesForSubjectByStudent>();
            service.AddScoped<GetNotesForSubjectByStudentUseCase.BusinessValidations.IStudentIdValidation, GetNotesForSubjectByStudentUseCase.BusinessValidations.StudentIdValidation>();
        }

        public static void GetStudentsByCatalogUseCase(this IServiceCollection service)
        {
            service.AddScoped<IGetStudentsByCatalog, GetStudentsByCatalog>();
            service.AddScoped<GetStudentsByCatalogUseCase.BusinessValidation.ICatalogIdValidation, GetStudentsByCatalogUseCase.BusinessValidation.CatalogIdValidation>();
        }

        public static void GetSubjectsForCatalogUseCase(this IServiceCollection service)
        {
            service.AddScoped<IGetSubjectsForCatalog, GetSubjectsForCatalog>();
            service.AddScoped<GetSubjectsForCatalogUseCase.BusinessValidation.ICatalogIdValidation, GetSubjectsForCatalogUseCase.BusinessValidation.CatalogIdValidation>();
        }

        public static void AddNuggets(this IServiceCollection service)
        {
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
