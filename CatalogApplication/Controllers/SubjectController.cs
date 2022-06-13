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

        [HttpPost("AddSubjectToCatalog")]
        public IActionResult AddSubjectToCatalog(AddSubjectToCatalogModel model)
        {
            _addSubjectToCatalog.AddSubjectToTheCatalog(model);
            return Ok();
        }

        [HttpGet("GetAllCatalogsForSubjectId")]
        public IActionResult GetAllCatalogsForSubjectId(int id)
        {
            var result = _getAllCatalogForSubject.GetAllCatalogsForSubjectId(id);
            return Ok(result);
        }

        [HttpPost("")]
        public IActionResult CreateSubject(SubjectModel request)
        {
            var result = _subjectService.CreateSubject(request);

            if (result)
                return Ok();
            else return BadRequest();
        }
    }
}
