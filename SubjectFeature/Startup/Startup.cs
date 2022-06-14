﻿using EFORM.Models;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SubjectFeature.AddSubjectToCatalogUseCase;
using SubjectFeature.CrudUsecase;
using SubjectFeature.GetAllCatalogsForSubject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SubjectFeature.Startup
{
    public static class Startup
    {
        public static void AddSubjectFeatures(this IServiceCollection service, string efConnectionString)
        {
            service.AddNuggets();
            service.AddEFDatabaseConnection(efConnectionString);
            service.GetAllCatalogForSubjectUseCase();
            service.CrudUseCase();
            service.AddSubjectToCatalogUseCase();
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
            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public static void GetAllCatalogForSubjectUseCase(this IServiceCollection service)
        {
            service.AddScoped<IGetAllCatalogForSubject, GetAllCatalogForSubject>();
            service.AddScoped<GetAllCatalogsForSubjectUseCase.BusinessValidations.ISubjectIdValidation, GetAllCatalogsForSubjectUseCase.BusinessValidations.SubjectIdValidation>();
        }

        public static void CrudUseCase(this IServiceCollection service)
        {
            service.AddScoped<ISubjectService, SubjectService>();
        }

        public static void AddSubjectToCatalogUseCase(this IServiceCollection service)
        {
            service.AddScoped<IAddSubjectToCatalog, AddSubjectToCatalog>();
            service.AddScoped<AddSubjectToCatalogUseCase.Commands.IInsertIntoSubjectCatalog, AddSubjectToCatalogUseCase.Commands.InsertIntoSubjectCatalog>();
            service.AddScoped<AddSubjectToCatalogUseCase.BusinessValidations.ICatalogIdValidation, AddSubjectToCatalogUseCase.BusinessValidations.CatalogIdValidation>();
            service.AddScoped<AddSubjectToCatalogUseCase.BusinessValidations.ISubjectIdValidation, AddSubjectToCatalogUseCase.BusinessValidations.SubjectIdValidation>();
        }
    }
}
