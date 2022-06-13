using AutoMapper;
using EFORM.Models;
using GradesFeature.AddNoteForStudentUseCase.BusinessValidation;
using GradesFeature.AddNoteForStudentUseCase.Commands;
using Microsoft.Extensions.Logging;
using SharedLibrary;
using SharedLibrary.GradeFeatureException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesFeature.AddNoteForStudentUseCase
{
    public class AddNoteForStudent : IAddNoteForStudent
    {
        private readonly CatalogHomeworkContext _context;
        private readonly ILogger<AddNoteForStudent> _logger;
        private readonly IMapper _mapper;
        private readonly IInsertNoteForStudent _insertNoteForStudent;
        private readonly ISubjectIdValidation _subjectIdValidation;
        private readonly ICatalogIdValidation _catalogIdValidation;
        private readonly IStudentIdValidation _studentIdValidation;
        public AddNoteForStudent(CatalogHomeworkContext context, ILogger<AddNoteForStudent> logger, IMapper mapper, IInsertNoteForStudent insertNoteForStudent, ISubjectIdValidation subjectIdValidation, ICatalogIdValidation catalogIdValidation, IStudentIdValidation studentIdValidation)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _insertNoteForStudent = insertNoteForStudent;
            _subjectIdValidation = subjectIdValidation;
            _catalogIdValidation = catalogIdValidation;
            _studentIdValidation = studentIdValidation;
        }
        public bool AddNote(AddNoteForStudentModel request)
        {
            ValidateRequest(request);

            ValidateBusinessRules(request.CatalogId, request.MaterieId, request.StudentId);

            var noteID = InsertNote(request);

            ValidateNoteId(noteID);

            return true;
        }

        private int InsertNote(AddNoteForStudentModel model)
        {
            var noteID = _insertNoteForStudent.InsertNote(model);

            return noteID;
        }

        private void ValidateBusinessRules(int catalogID, int subjectID, int studentID)
        {
            var catalogExists = _catalogIdValidation.Exists(catalogID);

            if (!catalogExists)
            {
                _logger.LogError("Catalog doesn't exists when trying to add note for student!");
                throw new CatalogIdDoesNotExistsException($"No catalog with id: {catalogID} exists in db!");
            }

            var subjectExists = _subjectIdValidation.Exists(subjectID);

            if (!subjectExists)
            {
                _logger.LogError("Subject doesn't exists when trying to add note for student!");
                throw new SubjectIdDoesNotExistsException($"No subject with id: {subjectID} exists in db!");
            }

            var studentExists = _studentIdValidation.Exists(studentID);
            if (!studentExists)
            {
                _logger.LogError("Subject doesn't exists when trying to add note for student!");
                throw new InvalidStudentIdException($"No student with id: {studentID} exists in db!");
            }
        }

        private void ValidateRequest(AddNoteForStudentModel model)
        {
            var addNote = new AddNoteForStudentValidation();
            var result = addNote.Validate(model);

            if (!result.IsValid)
            {
                _logger.LogError("Model is not valid to add note to a student");
                throw new AddNoteForStudentModelNotValidException("The model for adding a subject to catalog is not a valid model!");
            }
        }

        private void ValidateNoteId(int entityID)
        {
            if (entityID == 0)
            {
                throw new ("NoteID in enitity not found after insertion!");
            }
        }
    }
}
