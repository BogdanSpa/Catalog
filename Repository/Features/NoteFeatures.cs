using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Features
{
    public class NoteFeatures : INoteFeatures
    {
        private readonly CatalogHomeworkContext _context;

        public NoteFeatures(CatalogHomeworkContext context)
        {
            _context = context;
        }

        public void AddNoteForStudentId(int studentId, int materieId, byte note, int catalogId)
        {
            Note nota = new Note()
            {
                StudentId = studentId,
                MaterieId = materieId,
                Nota = note,
                IssueDate = DateTime.Now,
            };


            try
            {
                _context.Notes.Add(nota);
                _context.SaveChanges();

                var NotaId = nota.Id;

                NoteList noteList = new NoteList()
                {
                    CatalogId = catalogId,
                    NotaId = NotaId
                };

                _context.NoteLists.Add(noteList);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
