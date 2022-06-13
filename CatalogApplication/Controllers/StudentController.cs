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
        
        private readonly IGetNotesForSubjectByStudent _getNotesForSubjectByStudent;
        private readonly IGetStudentsByClass _getStudentsByClass;
        private readonly IGetStudentsWithNotesOnSubjectCatalog _getStudentsWithNotesOnSubjectCatalog;
        

        public StudentController(IGetNotesForSubjectByStudent getNotesForSubjectByStudent, 
            IGetStudentsByClass getStudentsByClass, IGetStudentsWithNotesOnSubjectCatalog getStudentsWithNotesOnSubjectCatalog)
        {
            
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
        public IActionResult GetStudentsWithNotesOnSubjectCatalog(int subjectID, int catalogID)
        {
            var result = _getStudentsWithNotesOnSubjectCatalog.GetStudentsSubjectNotes(subjectID, catalogID);

            return Ok(result);
        }


    }
}
