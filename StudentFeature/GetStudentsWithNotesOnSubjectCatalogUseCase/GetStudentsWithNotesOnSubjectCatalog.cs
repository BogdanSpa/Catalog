using AutoMapper;
using EFORM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharedLibrary.StudentFeatureException;
using SharedLibrary.SubjectFeatureException;
using StudentFeature.GetStudentsWithNotesOnSubjectCatalogUseCase.BusinessValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeature.GetStudentsWithNotesOnSubjectCatalogUseCase
{
    public class GetStudentsWithNotesOnSubjectCatalog : IGetStudentsWithNotesOnSubjectCatalog
    {
        private readonly CatalogHomeworkContext _context;
        private readonly ICatalogIdValidation _catalogIdValidation;
        private readonly ISubjectIdValidation _subjectIdValidation;
        private readonly IMapper _mapper;
        private readonly ILogger<GetStudentsWithNotesOnSubjectCatalog> _logger;
        public GetStudentsWithNotesOnSubjectCatalog(CatalogHomeworkContext context, ICatalogIdValidation catalogIdValidation, ISubjectIdValidation subjectIdValidation, ILogger<GetStudentsWithNotesOnSubjectCatalog> logger, IMapper mapper)
        {
            _context = context;
            _catalogIdValidation = catalogIdValidation;
            _subjectIdValidation = subjectIdValidation;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<GetStudentsWithNotesOnSubjectCatalogResponse> GetStudentsSubjectNotes(int subjectID, int catalogID)
        {
            var request = new GetStudentsWithNotesOnSubjectCatalogRequest { SubjectID = subjectID, CatalogID = catalogID };
            ValidateRequest(request);

            ValidateBusinessRules(request.CatalogID, request.SubjectID);

            return GetStudents(request);
        }

        private IEnumerable<GetStudentsWithNotesOnSubjectCatalogResponse> GetStudents(GetStudentsWithNotesOnSubjectCatalogRequest request)
        {
            try
            {
                int catalogID = request.CatalogID;
                int subjectID = request.SubjectID;
                var query = _context.NoteLists.Where(c => c.CatalogId == catalogID).Include(s => s.Nota)
                    .Where(s => s.Nota.MaterieId == subjectID)
                    .Select(s => s.Nota.Student).Distinct();

                var result = _mapper.Map<IQueryable<Student>, IEnumerable<GetStudentsWithNotesOnSubjectCatalogResponse>>(query);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an internal server error when trying to GetStudentsSubjectNotes");
                throw new GetStudentsWithNotesOnSubjectCatalogInternalServerErrorException("There is an internal servcer error!");
            }
        }

        private void ValidateRequest(GetStudentsWithNotesOnSubjectCatalogRequest request)
        {
            var GetNotesOnSubjectValidation = new GetStudentsWithNotesOnSubjectCatalogValidation();
            var result = GetNotesOnSubjectValidation.Validate(request);

            if (!result.IsValid)
            {
                _logger.LogError("Model is not valid");
                throw new GetStudentsWithNotesOnSubjectInvalidException("The model for requesting notes for each subject for each student is invalid!");
            }
        }
        private void ValidateBusinessRules(int catalogID, int subjectID)
        {
            var catalogExists = _catalogIdValidation.Exists(catalogID);

            if (!catalogExists)
            {
                _logger.LogError("Catalog doesn't exists when trying to get notes for each student grouped by subject!");
                throw new CatalogIdDoesNotExistsException($"No catalog with id: {catalogID} exists in db!");
            }

            var subjectExists = _subjectIdValidation.Exists(subjectID);

            if (!subjectExists)
            {
                _logger.LogError("Subject doesn't exists when trying to get notes for each student grouped by subject!");
                throw new SubjectIdDoesNotExistsException($"No subject with id: {subjectID} exists in db!");
            }
        }

    }
}
