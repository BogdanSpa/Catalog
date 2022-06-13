using AutoMapper;
using EFORM.Models;
using Microsoft.Extensions.Logging;
using SharedLibrary.StudentFeatureException;
using StudentFeature.GetStudentsByClassUseCase;
using StudentFeature.GetStudentsByClassUseCase.BusinessValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeature.GetStudentByClassUseCase
{
    public class GetStudentsByClass : IGetStudentsByClass
    {
        private readonly CatalogHomeworkContext _context;
        private readonly IClasaValidation _clasaValidation;
        private readonly IMapper _mapper;
        private readonly ILogger<GetStudentsByClass> _logger;
        public GetStudentsByClass(CatalogHomeworkContext context, IClasaValidation clasaValidation, IMapper mapper, ILogger<GetStudentsByClass> logger)
        {
            _context = context;
            _clasaValidation = clasaValidation;
            _mapper = mapper;
            _logger = logger;
        }
        //Ex 1
        public IEnumerable<GetStudentsByClassResponse> GetStudentsOnClass(string clasa)
        {
            ValidateRequest(clasa);

            ValidateBusinessRules(clasa);

            return GetStudents(clasa);
        }

        private IEnumerable<GetStudentsByClassResponse> GetStudents(string clasa)
        {
            try
            {
                var IdCatalogForClass = _context.Catalogs.FirstOrDefault(c => c.Clasa == clasa).Id;

                var query = _context.NoteLists.Where(n => n.CatalogId == IdCatalogForClass).Select(s => s.Nota.Student).Distinct();

                var result = _mapper.Map<IQueryable<Student>, IEnumerable<GetStudentsByClassResponse>>(query);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("There was an internal server error while trying to GetStudentsByClass()");
                throw new GetStudentsByClassInternalServerErrorException("The data couldnt be retrieved from db.");
            }
        }

        private void ValidateRequest(string clasa)
        {
            if (string.IsNullOrEmpty(clasa))
            {
                _logger.LogError("Class is not valid. It is empty or null");
                throw new GetStudentByClassIsInvalidException("Class is not correct or is empty or null!");
            }
        }

        private void ValidateBusinessRules(string clasa)
        {
            var classExists = _clasaValidation.Exists(clasa);

            if(!classExists)
            {
                _logger.LogError("Entered class does not have a catalog");
                throw new ClassNotAssignedToCatalogException("The class is not assigned to any catalog!");
            }
        }
    }
}
