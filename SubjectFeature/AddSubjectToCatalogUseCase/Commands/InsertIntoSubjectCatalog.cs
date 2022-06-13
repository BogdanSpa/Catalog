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
        int Insert(AddSubjectToCatalogModel request);
    }

    public class InsertIntoSubjectCatalog : IInsertIntoSubjectCatalog
    {

        private readonly CatalogHomeworkContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public InsertIntoSubjectCatalog(CatalogHomeworkContext context, IMapper mapper, ILogger logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public int Insert(AddSubjectToCatalogModel request)
        {
            SubjectCatalog subjectCatalog = _mapper.Map<SubjectCatalog>(request);

            try
            {
                _context.SubjectCatalogs.Add(subjectCatalog);
                _context.SaveChanges();
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
