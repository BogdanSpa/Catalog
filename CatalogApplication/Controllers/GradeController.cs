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

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("AddNoteForStudent")]
        public async Task<IActionResult> AddNoteForStudent(AddNoteForStudentModel model)
        {
            bool isValid = await _addNoteForStudent.AddNote(model);

            if(isValid)
            {
                return Ok("Note added");
            }
            
            return BadRequest("Note can not be added!");
        }
    }
}
