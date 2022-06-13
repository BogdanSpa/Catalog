using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GradesFeature.AddNoteForStudentUseCase;
using GradesFeature.CrudUsecase;
namespace CatalogApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly INoteService _context;
        private readonly IAddNoteForStudent _addNoteForStudent;

        public GradeController(INoteService context, IAddNoteForStudent addNoteForStudent)
        {
            _context = context;
            _addNoteForStudent = addNoteForStudent;
        }

        [HttpPost("AddNoteForStudent")]
        public IActionResult AddNoteForStudent(AddNoteForStudentModel model)
        {
            bool isValid = _addNoteForStudent.AddNote(model);

            if(isValid)
            {
                return Ok("Note added");
            }
            return Ok("Note can not be added!");
        }
    }
}
