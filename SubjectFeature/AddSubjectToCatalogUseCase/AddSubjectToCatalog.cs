using AutoMapper;
using EFORM.Models;
using Microsoft.Extensions.Logging;
using SharedLibrary.SubjectFeatureException;
using SubjectFeature.AddSubjectToCatalogUseCase.BusinessValidations;
using SubjectFeature.AddSubjectToCatalogUseCase.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectFeature.AddSubjectToCatalogUseCase
{
    public class AddSubjectToCatalog : IAddSubjectToCatalog
    {
        private readonly IInsertIntoSubjectCatalog _insertIntoSubjectCatalog;
        private readonly ICatalogIdValidation _catalogIdValidation;
        private readonly ISubjectIdValidation _subjectIdValidation;
        private readonly IMapper _mapper;
        private readonly ILogger<AddSubjectToCatalog> _logger;

        public AddSubjectToCatalog(IInsertIntoSubjectCatalog insertIntoSubjectCatalog, IMapper mapper, ILogger<AddSubjectToCatalog> logger, ICatalogIdValidation catalogIdValidation, ISubjectIdValidation subjectIdValidation)
        {
            _insertIntoSubjectCatalog = insertIntoSubjectCatalog;
            _mapper = mapper;
            _logger = logger;
            _catalogIdValidation = catalogIdValidation;
            _subjectIdValidation = subjectIdValidation;
        }

        public string AddSubjectToTheCatalog(AddSubjectToCatalogModel request)
        {
            //1 Validate request
            ValidateRequest(request);

            //2 Validate bussines rules
            ValidateBusinessRules(request.CatalogID, request.MaterieID);

            //3 Insert into table
            var entityId = InsertSubject(request);

            //4 Validate entityID
            ValidateSubjectCatalogID(entityId);

            return "Subject was added to the catalog!";

        }

        private void ValidateRequest(AddSubjectToCatalogModel request)
        {
            var addSubjectToCatalogValidation = new AddSubjectToCatalogValidation();
            var result = addSubjectToCatalogValidation.Validate(request);

            if(!result.IsValid)
            {
                _logger.LogError("Model is not valid for entity: SubjectCatalog");
                throw new AddSubjectToCatalogModelNotValidException("The model for adding a subject to catalog is not a valid model!");
            }
        }

        private void ValidateBusinessRules(int catalogID, int subjectID)
        {
            var catalogExists = _catalogIdValidation.Exists(catalogID);

            if(!catalogExists)
            {
                _logger.LogError("Catalog doesn't exists when trying to add subject to catalog!");
                throw new CatalogIdDoesNotExistsException($"No catalog with id: {catalogID} exists in db!");
            }

            var subjectExists = _subjectIdValidation.Exists(subjectID);

            if(!subjectExists)
            {
                _logger.LogError("Subject doesn't exists when trying to add subject to catalog!");
                throw new SubjectIdDoesNotExistsException($"No subject with id: {subjectID} exists in db!");
            }
        }
        private int InsertSubject(AddSubjectToCatalogModel request)
        {
            var id = _insertIntoSubjectCatalog.Insert(request);

            return id;
        }

        private void ValidateSubjectCatalogID(int entityID)
        {
            if(entityID == 0)
            {
                throw new SubjectCatalogIdNotFoundException("SubjectCatalogId not found after insertion!");
            }
        }
    }
}
