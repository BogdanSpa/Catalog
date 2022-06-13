using AutoMapper;
using CatalogFeature.GetSubjectsForCatalogUseCase.BusinessValidation;
using EFORM.Models;
using Microsoft.Extensions.Logging;
using SharedLibrary.CatalogFeatureException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogFeature.GetSubjectsForCatalogUseCase
{
    public class GetSubjectsForCatalog : IGetSubjectsForCatalog
    {
        private readonly CatalogHomeworkContext _context;
        private readonly ILogger<GetSubjectsForCatalog> _logger;
        private readonly ICatalogIdValidation _catalogIdValidation;
        private readonly IMapper _mapper;
        public GetSubjectsForCatalog(CatalogHomeworkContext context, ILogger<GetSubjectsForCatalog> logger, ICatalogIdValidation catalogIdValidation, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _catalogIdValidation = catalogIdValidation;
            _mapper = mapper;
        }

        public IEnumerable<GetSubjectForCatalogResponse> GetSubjects(int catalogID)
        {
            ValidateRequest(catalogID);

            ValidateBusinessRules(catalogID);

            return GetAllSubjects(catalogID);
        }
        private IEnumerable<GetSubjectForCatalogResponse> GetAllSubjects(int catalogID)
        {
            try
            {
                var query = _context.NoteLists.Where(x => x.CatalogId == catalogID).Select(x => x.Nota.Materie).Distinct();

                var result = _mapper.Map<IQueryable<Subject>, IEnumerable<GetSubjectForCatalogResponse>>(query);

                return result;
            }
            catch (Exception)
            {
                _logger.LogError("InternalServerError when trying to get subjects for catalog");
                throw new GetSubjectsForCatalogInternalServerErrorException("InternalServerError when trying to get subjects for catalog");
            }
        }

        private void ValidateBusinessRules(int catalogID)
        {
            var catalogExists = _catalogIdValidation.Exists(catalogID);

            if (!catalogExists)
            {
                _logger.LogError("Catalog doesn't exists when trying to call GetStudentsByCatalog!");
                throw new StudentIdValidationException($"No catalog with id: {catalogID} exists in db!");
            }
        }
        private void ValidateRequest(int catalogID)
        {
            if (catalogID == 0)
            {
                _logger.LogError("Catalog ID is invalid!");
                throw new CatalogIdNotValidException("Catalog id is invalid!");
            }
        }


    }
}
