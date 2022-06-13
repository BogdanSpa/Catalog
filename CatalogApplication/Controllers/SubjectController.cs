using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubjectFeature.AddSubjectToCatalogUseCase;
using SubjectFeature.CrudUsecase;
using SubjectFeature.GetAllCatalogsForSubject;

namespace CatalogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IAddSubjectToCatalog _addSubjectToCatalog;
        private readonly ISubjectService _subjectService;
        private readonly IGetAllCatalogForSubject _getAllCatalogForSubject;
        private readonly IMapper _mapper;

        public SubjectController(IAddSubjectToCatalog addSubjectToCatalog, ISubjectService subjectService, IGetAllCatalogForSubject getAllCatalogForSubject, IMapper mapper)
        {
            _addSubjectToCatalog = addSubjectToCatalog;
            _subjectService = subjectService;
            _getAllCatalogForSubject = getAllCatalogForSubject;
            _mapper = mapper;
        }

        [HttpGet("AddSubjectToCatalog")]
        public IActionResult AddSubjectToCatalog(AddSubjectToCatalogModel model)
        {
            
            return Ok();
        }
    }
}
