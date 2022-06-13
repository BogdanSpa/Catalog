using CatalogFeature.CrudUsecase;
using CatalogFeature.GetAverageForEachSubjectUsecase;
using CatalogFeature.GetNotesForCatalogUsecase;
using CatalogFeature.GetNotesForSubjectByStudentUseCase;
using CatalogFeature.GetStudentsByCatalogUseCase;
using CatalogFeature.GetSubjectsForCatalogUseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CatalogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _context;
        private readonly IGetAverageForEachSubject _getAverageForEachSubject;
        private readonly IGetNotesForCatalog _getNotesForCatalog;
        private readonly IGetNotesForSubjectByStudent _getNotesForSubjectByStudent;
        private readonly IGetStudentsByCatalog _getStudentsByCatalog;
        private readonly IGetSubjectsForCatalog _getSubjectsForCatalog;
       

        public CatalogController(ICatalogService context, IGetAverageForEachSubject getAverageForEachSubject, IGetNotesForCatalog getNotesForCatalog, 
            IGetNotesForSubjectByStudent getNotesForSubjectByStudent, IGetStudentsByCatalog getStudentsByCatalog, IGetSubjectsForCatalog getSubjectsForCatalog)
        {
            _context = context;
            _getAverageForEachSubject = getAverageForEachSubject;
            _getNotesForCatalog = getNotesForCatalog;
            _getNotesForSubjectByStudent = getNotesForSubjectByStudent;
            _getStudentsByCatalog = getStudentsByCatalog;
            _getSubjectsForCatalog = getSubjectsForCatalog;
        }

        [HttpGet("GetAverageForEachSubject")]
        public  IActionResult GetAverageForEachSubject(int id)
        {
            var result = _getAverageForEachSubject.GetAverageForSubjects(id);

            return Ok(result);
        }

        [HttpGet("GetNotesForCatalog")]
        public IActionResult GetNotesForCatalog(int id)
        {
            var result = _getNotesForCatalog.GetNotes(id);

            return Ok(result);
        }

        [HttpGet("GetNotesForSubjectByStudent")]
        public IActionResult GetNotesForSubjectByStudent(int id)
        {
            var result = _getNotesForSubjectByStudent.GetNotes(id);

            return Ok(result);
        }

        [HttpGet("GetStudentsByCatalog")]
        public IActionResult GetStudentsByCatalog(int id)
        {
            var result = _getStudentsByCatalog.GetStudents(id);

            return Ok(result);
        }

        [HttpGet("GetSujectsForCatalog")]
        public IActionResult GetSubjectsForCatalog(int id)
        {
            var result = _getSubjectsForCatalog.GetSubjects(id);

            return Ok(result);
        }
    }
}
