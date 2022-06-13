using AutoMapper;
using CatalogFeature.GetStudentsByCatalogUseCase.BusinessValidation;
using EFORM.Models;
using Microsoft.Extensions.Logging;
using SharedLibrary.CatalogFeatureException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogFeature.GetStudentsByCatalogUseCase
{
    public class GetStudentsByCatalog : IGetStudentsByCatalog
    {
        private readonly CatalogHomeworkContext _context;
        private readonly ILogger<GetStudentsByCatalog> _logger;
        private readonly IMapper _mapper;
        private readonly ICatalogIdValidation _catalogIdValidation;
        public GetStudentsByCatalog(CatalogHomeworkContext context, ILogger<GetStudentsByCatalog> logger, IMapper mapper, ICatalogIdValidation catalogIdValidation)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _catalogIdValidation = catalogIdValidation;
        }
        public IEnumerable<GetStudentsByCatalogResponse> GetStudents(int catalogID)
        {
            ValidateRequest(catalogID);

            ValidateBusinessRules(catalogID);

            return GetAllStudents(catalogID);
        }
        private IEnumerable<GetStudentsByCatalogResponse> GetAllStudents (int catalogID)
        {
            try
            {
                var query = _context.NoteLists.Where(n => n.CatalogId == catalogID).Select(s => s.Nota.Student).Distinct();

                var result = _mapper.Map<IQueryable<Student>, IEnumerable<GetStudentsByCatalogResponse>>(query);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("An internal server error has occured when trying to call GetStudents");
                throw new GetAllStudentsInternalServerError("There was an internal server error when trying to get data from db");
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
