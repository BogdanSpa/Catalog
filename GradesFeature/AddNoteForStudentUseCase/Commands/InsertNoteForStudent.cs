using AutoMapper;
using EFORM.Models;
using Microsoft.Extensions.Logging;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesFeature.AddNoteForStudentUseCase.Commands
{
    public interface IInsertNoteForStudent
    {
        int InsertNote(AddNoteForStudentModel model);
    }

    public class InsertNoteForStudent : IInsertNoteForStudent
    {
        private readonly ILogger<InsertNoteForStudent> _logger;
        private readonly IMapper _mapper;
        private readonly CatalogHomeworkContext _context;

        public InsertNoteForStudent(ILogger<InsertNoteForStudent> logger, IMapper mapper, CatalogHomeworkContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public int InsertNote(AddNoteForStudentModel model)
        {
            var note = _mapper.Map<Note>(model);
            note.IssueDate = DateTime.Now;
            try
            {
                _context.Notes.Add(note);
                _context.SaveChanges();


                NoteList noteList = new NoteList()
                {
                    CatalogId = model.CatalogId,
                    NotaId = note.Id
                };

                _context.NoteLists.Add(noteList);
                _context.SaveChanges();

                return note.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Internal Server Error when trying to add note to db");
                throw new AddNoteForStudentInternalServerErrorException("The note can not be added due to an internal server error");

            }
        }
    }
}
