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

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("AddSubjectToCatalog")]
        public IActionResult AddSubjectToCatalog(AddSubjectToCatalogModel model)
        {
            _addSubjectToCatalog.AddSubjectToTheCatalog(model);
            return Ok("Added");
        }

        [HttpGet("GetAllCatalogsForSubjectId")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetAllCatalogsForSubjectId(int id)
        {
            var result = _getAllCatalogForSubject.GetAllCatalogsForSubjectId(id);

            return Ok(result);
        }

        [HttpPost("CreateSubject")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateSubject(SubjectModel request)
        {
            var result = _subjectService.CreateSubject(request);

            return Created("api/Subject", request.Nume);
        }
    }
}
