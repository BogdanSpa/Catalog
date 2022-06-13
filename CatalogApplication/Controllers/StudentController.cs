using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentFeature.CrudUsecase;
using StudentFeature.GetNotesForSubjectByStudentUseCase;
using StudentFeature.GetStudentByClassUseCase;
using StudentFeature.GetStudentsWithNotesOnSubjectCatalogUseCase;

namespace CatalogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _context;
        private readonly IGetNotesForSubjectByStudent _getNotesForSubjectByStudent;
        private readonly IGetStudentsByClass _getStudentsByClass;
        private readonly IGetStudentsWithNotesOnSubjectCatalog _getStudentsWithNotesOnSubjectCatalog;
        private readonly IMapper _mapper;

        public StudentController(IMapper mapper, IStudentService context, IGetNotesForSubjectByStudent getNotesForSubjectByStudent, 
            IGetStudentsByClass getStudentsByClass, IGetStudentsWithNotesOnSubjectCatalog getStudentsWithNotesOnSubjectCatalog)
        {
            _mapper = mapper;
            _context = context;
            _getNotesForSubjectByStudent = getNotesForSubjectByStudent;
            _getStudentsByClass = getStudentsByClass;
            _getStudentsWithNotesOnSubjectCatalog = getStudentsWithNotesOnSubjectCatalog;
        }

        [HttpGet("GetNotesForSubjectByStudent")]
        public IActionResult GetNotesForSubjectByStudent(int id)
        {
            var result = _getNotesForSubjectByStudent.GetNotesForSubjectByStudentId(id);

            return Ok(result);
        }

        [HttpGet("GetStudentsByClass")]
        public IActionResult GetStudentsByClass(string Cls)
        {
            var result = _getStudentsByClass.GetStudentsOnClass(Cls);

            return Ok(result);
        }

        [HttpGet("GetStudentsWithNotesSubject")]
        public IActionResult GetStudentsWithNotesOnSubjectCatalog(GetStudentsWithNotesOnSubjectCatalogRequest model)
        {
            var result = _getStudentsWithNotesOnSubjectCatalog.GetStudentsSubjectNotes(model);

            return Ok(result);
        }


    }
}
