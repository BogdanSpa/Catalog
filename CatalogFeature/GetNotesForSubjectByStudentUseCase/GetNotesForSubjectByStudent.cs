using CatalogFeature.GetNotesForSubjectByStudentUseCase.BusinessValidations;
using EFORM.Models;
using Microsoft.Extensions.Logging;
using SharedLibrary.CatalogFeatureException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogFeature.GetNotesForSubjectByStudentUseCase
{
    public class GetNotesForSubjectByStudent : IGetNotesForSubjectByStudent
    {
        private readonly CatalogHomeworkContext _context;
        private readonly ILogger<GetNotesForSubjectByStudent> _logger;
        private readonly IStudentIdValidation _studentIdValidation;
        public GetNotesForSubjectByStudent(CatalogHomeworkContext context, ILogger<GetNotesForSubjectByStudent> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IQueryable<GetNotesForSubjectStudentModel> GetNotesForSubject(int studentID)
        {
            ValidateRequest(studentID);
            ValidateBusinessRules(studentID);
            return GetNotes(studentID);
        }
        public IQueryable<GetNotesForSubjectStudentModel> GetNotes(int studentID)
        {
            var query = _context.Notes.Where(n => n.StudentId == studentID);
            try
            {
                var result = query.GroupBy(n => n.Materie.Nume,
                    (k, c) => new GetNotesForSubjectStudentModel()
                    {
                        Subject = k,
                        Notes = c.Select(n => n.Nota).ToList()
                    });

                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError("Internal server error when trying to get data from db at GetNotesForSubject!");
                throw new GetNotesForSubjectInternalServerErrorException("Error when trying to fetch data from db!");
            }
        }

        private void ValidateBusinessRules(int studentID)
        {
            var studentExists = _studentIdValidation.Exists(studentID);

            if (!studentExists)
            {
                _logger.LogError("Catalog doesn't exists when trying to call GetAverageForEachSubject!");
                throw new CatalogIdDoesNotExistsException($"No subject with id: {studentID} exists in db!");
            }
        }
        private void ValidateRequest(int studentID)
        {
            if (studentID == 0)
            {
                _logger.LogError("Student ID is invalid!");
                throw new CatalogIdNotValidException("Student ID is invalid!");
            }
        }
    }
}
