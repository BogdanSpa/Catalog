using EFORM.Models;
using Microsoft.Extensions.Logging;
using SharedLibrary.StudentFeatureException;
using StudentFeature.GetNotesForSubjectByStudentUseCase.BusinessValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeature.GetNotesForSubjectByStudentUseCase
{
    public class GetNotesForSubjectByStudent : IGetNotesForSubjectByStudent
    {
        private readonly CatalogHomeworkContext _context;
        private readonly IStudentIdValidation _studentIdValidation;
        private readonly ILogger _logger;
        public GetNotesForSubjectByStudent(CatalogHomeworkContext context, IStudentIdValidation studentIdValidation, ILogger logger)
        {
            _context = context;
            _studentIdValidation = studentIdValidation;
            _logger = logger;
        }

        public IQueryable<GetNotesForSubjectStudentModel> GetNotesForSubjectByStudentId(int studentID)
        {
            ValidateRequest(studentID);

            ValidateBusinessRules(studentID);

            return GetNotes(studentID);
        }
        private IQueryable<GetNotesForSubjectStudentModel> GetNotes(int id)
        {
            var query = _context.Notes.Where(n => n.StudentId == id);

            var result = query.GroupBy(n => n.Materie.Nume,
                (k, c) => new GetNotesForSubjectStudentModel()
                {
                    Subject = k,
                    Notes = c.Select(s => s.Nota).ToList()
                });

            return result;
        }
        private void ValidateRequest(int id)
        {
            if (id <= 0)
            {
                _logger.LogError("The request for student is invalid and must be greater than 0!");
                throw new InvalidStudentIdException("The current ID is invalid and must be greater than 0");
            }
        }
        private void ValidateBusinessRules(int studentID)
        {
            var studentExists = _studentIdValidation.Exists(studentID);

            if(!studentExists)
            {
                _logger.LogError("The request for studentID is invalid and must be greater than 0!");
                throw new StudentNotFoundForStudentIdException($"No student exists in db with id: {studentID}");
            }
        }
    }
}
