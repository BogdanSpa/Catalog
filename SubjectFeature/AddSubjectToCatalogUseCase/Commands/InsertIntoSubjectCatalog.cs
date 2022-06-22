using AutoMapper;
using EFORM.Models;
using Microsoft.Extensions.Logging;
using SharedLibrary.SubjectFeatureException;
using SubjectFeature.CrudUsecase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectFeature.AddSubjectToCatalogUseCase.Commands
{
    public interface IInsertIntoSubjectCatalog
    {
        Task<int> Insert(AddSubjectToCatalogModel request);
    }

    public class InsertIntoSubjectCatalog : IInsertIntoSubjectCatalog
    {

        private readonly CatalogHomeworkContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<InsertIntoSubjectCatalog> _logger;

        public InsertIntoSubjectCatalog(CatalogHomeworkContext context, IMapper mapper, ILogger<InsertIntoSubjectCatalog> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Insert(AddSubjectToCatalogModel request)
        {
            var subjectCatalog = _mapper.Map<SubjectCatalog>(request);

            try
            {
                await _context.SubjectCatalogs.AddAsync(subjectCatalog);
                await _context.SaveChangesAsync();
                return subjectCatalog.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while inserting into SubjectCatalog entity: {ex}");
                throw new InsertIntoSubjectCatalogInternalServerErrorException("Error while inserting into SubjectCatalog! The subject is not added to catalog!");
            }
        }
    }
}
