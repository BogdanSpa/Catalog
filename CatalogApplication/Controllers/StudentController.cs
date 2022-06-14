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


        public StudentController(IGetNotesForSubjectByStudent getNotesForSubjectByStudent,
            IGetStudentsByClass getStudentsByClass, IGetStudentsWithNotesOnSubjectCatalog getStudentsWithNotesOnSubjectCatalog, IStudentService studentService)
        {
            _getNotesForSubjectByStudent = getNotesForSubjectByStudent;
            _getStudentsByClass = getStudentsByClass;
            _getStudentsWithNotesOnSubjectCatalog = getStudentsWithNotesOnSubjectCatalog;
            _context = studentService;
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetNotesForSubjectByStudent")]
        public IActionResult GetNotesForSubjectByStudent(int id)
        {
            var result = _getNotesForSubjectByStudent.GetNotesForSubjectByStudentId(id);

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetStudentsByClass")]
        public IActionResult GetStudentsByClass(string Cls)
        {
            var result = _getStudentsByClass.GetStudentsOnClass(Cls);

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetStudentsWithNotesSubject")]
        public IActionResult GetStudentsWithNotesOnSubjectCatalog(int subjectID, int catalogID)
        {
            var result = _getStudentsWithNotesOnSubjectCatalog.GetStudentsSubjectNotes(subjectID, catalogID);

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public IActionResult CreateStudent(StudentModel model)
        {
            _context.CreateStudent(model);
            return Created("api/student", model.Nume);
        }

    }
}
