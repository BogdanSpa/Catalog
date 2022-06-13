using AutoMapper;
using EFORM.Models;
using Microsoft.Extensions.Logging;
using SharedLibrary.SubjectFeatureException;
using SubjectFeature.AddSubjectToCatalogUseCase.BusinessValidations;
using SubjectFeature.GetAllCatalogsForSubjectUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectFeature.GetAllCatalogsForSubject
{
    public class GetAllCatalogForSubject : IGetAllCatalogForSubject
    {
        private readonly CatalogHomeworkContext _context;
        private readonly ISubjectIdValidation _subjectIdValidation;
        private readonly ILogger<GetAllCatalogForSubject> _logger;
        private readonly IMapper _mapper;
        public GetAllCatalogForSubject(CatalogHomeworkContext context, ISubjectIdValidation subjectIdValidation, ILogger<GetAllCatalogForSubject> logger, IMapper mapper)
        {
            _context = context;
            _subjectIdValidation = subjectIdValidation;
            _logger = logger;
            _mapper = mapper;
        }

        //8
        public IQueryable<GetAllCatalogsForSubjectResponse> GetAllCatalogsForSubjectId(int id)
        {
            //1 Validate request
            ValidateRequest(id);
            //2 Validate business rules
            ValidateBusinessRules(id);
            //3 Get result
            return GetCatalogs(id);
        }

        private IQueryable<GetAllCatalogsForSubjectResponse> GetCatalogs(int id)
        {
            var query = _context.SubjectCatalogs.Where(m => m.MaterieId == id).Select(m => m.Catalog);
            
            var result = _mapper.Map<IQueryable<Catalog>, IQueryable<GetAllCatalogsForSubjectResponse>>(query);
            return result;
        }

        private void ValidateRequest(int id)
        {
            if(id <= 0)
            {
                _logger.LogError("The request for subjectID is invalid and must be greater than 0!");
                throw new InvalidSubjectIdException("The current ID is invalid");
            }
        }

        private void ValidateBusinessRules(int subjectID)
        {
            var subjectExists = _subjectIdValidation.Exists(subjectID);

            if (!subjectExists)
            {
                _logger.LogError("Subject doesn't exists when trying to call GetAllCatalogForSubjectId!");
                throw new SubjectIdDoesNotExistsException($"No subject with id: {subjectID} exists in db!");
            }
        }
    }
}
