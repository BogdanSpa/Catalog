using CatalogFeature.GetAverageForEachSubjectUsecase.BusinessValidations;
using EFORM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharedLibrary.CatalogFeatureException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogFeature.GetAverageForEachSubjectUsecase
{
    public class GetAverageForEachSubject : IGetAverageForEachSubject
    {
        private readonly CatalogHomeworkContext _context;
        private readonly ILogger<GetAverageForEachSubject> _logger;
        private readonly ICatalogIdValidation _catalogIdValidation;
        public GetAverageForEachSubject(CatalogHomeworkContext context, ILogger<GetAverageForEachSubject> logger, ICatalogIdValidation catalogIdValidation)
        {
            _context = context;
            _logger = logger;
            _catalogIdValidation = catalogIdValidation;
        }

        public IEnumerable<GetAverageForEachSubjectModel> GetAverageForSubjects(int catalogID)
        {
            ValidateRequest(catalogID);

            ValidateBusinessRules(catalogID);

            return GetAverage(catalogID);
        }
        private IEnumerable<GetAverageForEachSubjectModel> GetAverage(int catalogID)
        {
            var query = _context.NoteLists.Where(c => c.CatalogId == catalogID).Include(m => m.Nota.Materie).Include(s => s.Nota.Student).Select(n => n.Nota);
            try
            {
                var result = query
                    .AsEnumerable()
                    .GroupBy(g => new { g.Student.Nume, g.Materie })
                    .Select(gr => new GetAverageForEachSubjectModel()
                    {
                        Student = gr.Key.Nume,
                        Average = gr.Average(n => n.Nota),
                        Subject = gr.Key.Materie.Nume
                    });

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Internal server error when trying to get data from db at GetAverageForSubjects");
                throw new GetAverageForSubjectsInternalServerErrorException("The data cannot be fetched from db!");
            }
        }

        private void ValidateBusinessRules(int catalogID)
        {
            var subjectExists = _catalogIdValidation.Exists(catalogID);

            if (!subjectExists)
            {
                _logger.LogError("Catalog doesn't exists when trying to call GetAverageForEachSubject!");
                throw new CatalogIdDoesNotExistsException($"No subject with id: {catalogID} exists in db!");
            }
        }
        private void ValidateRequest(int catalogID)
        {
            if (catalogID == 0)
                throw new CatalogIdNotValidException("CatalogID not valid");
        }
    }
}
