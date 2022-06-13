
using CatalogFeature.GetNotesForCatalogUsecase.BusinessValidations;
using EFORM.Models;
using Microsoft.Extensions.Logging;
using SharedLibrary.CatalogFeatureException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogFeature.GetNotesForCatalogUsecase
{
    public class GetNotesForCatalog : IGetNotesForCatalog
    {
        private readonly CatalogHomeworkContext _context;
        private readonly ILogger<GetNotesForCatalog> _logger;
        private readonly ICatalogIdValidation _catalogIdValidation;
        public GetNotesForCatalog(CatalogHomeworkContext context, ILogger<GetNotesForCatalog> logger, ICatalogIdValidation catalogIdValidation)
        {
            _context = context;
            _logger = logger;
            _catalogIdValidation = catalogIdValidation;
        }

        public IQueryable<GetNotesForCatalogModel> GetNotes(int catalogID)
        {
            ValidateRequest(catalogID);

            ValidateBusinessRules(catalogID);

            return GetNotesCatalog(catalogID);
        }
        private IQueryable<GetNotesForCatalogModel> GetNotesCatalog(int id)
        {
            try
            {
                var query = _context.NoteLists.Where(c => c.CatalogId == id)
                    .Select(n =>
                         new GetNotesForCatalogModel
                         {
                             Materie = n.Nota.Materie.Nume,
                             Student = n.Nota.Student.Nume + n.Nota.Student.Prenume,
                             Nota = n.Nota.Nota
                         });
                return query;
            }
            catch (Exception ex)
            {
                _logger.LogError("An internal server error has occured when trying to get data from db at GetNotesForCatalog");
                throw new GetNotesForCatalogInternalErrorException("There was an internal error when trying to get data from db!");
            }
        }
        private void ValidateBusinessRules(int catalogID)
        {
            var catalogExists = _catalogIdValidation.Exists(catalogID);

            if (!catalogExists)
            {
                _logger.LogError("Catalog doesn't exists when trying to call GetNotesForCatalog!");
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
