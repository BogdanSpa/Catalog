using CatalogFeature.Startup;
using StudentFeature.Startup;
using CatalogFeature.CrudUsecase;
using CatalogFeature.GetAverageForEachSubjectUsecase;
using CatalogFeature.GetNotesForCatalogUsecase;
using CatalogFeature.GetNotesForSubjectByStudentUseCase;
using CatalogFeature.GetStudentsByCatalogUseCase;
using CatalogFeature.GetSubjectsForCatalogUseCase;
using Microsoft.EntityFrameworkCore;
using EFORM.Models;
using SubjectFeature.Startup;
using GradesFeature.Startup;
using Serilog;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
});

var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var efConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddCatalogFeatures(efConnectionString);
builder.Services.AddStudentFeatures(efConnectionString);
builder.Services.AddSubjectFeatures(efConnectionString);
builder.Services.AddGradesFeatures(efConnectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
