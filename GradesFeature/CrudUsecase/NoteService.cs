using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesFeature.CrudUsecase
{
    public class NoteService : INoteService
    {
        private readonly CatalogHomeworkContext _context;

        public NoteService(CatalogHomeworkContext context)
        {
            _context = context;
        }
        public bool CreateNote(Note nota)
        {
            if (nota == null)
                return false;

            try
            {
                _context.Notes.Add(nota);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Note GetNote(int id)
        {
            return _context.Notes.FirstOrDefault(s => s.Id == id);
        }

        public bool UpdateNote(Student student)
        {
            var noteToBeUpdated = _context.Notes.FirstOrDefault(s => s.Id == student.Id);

            try
            {
                if (noteToBeUpdated != null)
                {
                    _context.Notes.Update(noteToBeUpdated);
                    _context.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                return true;
            }

            return false;
        }

        public bool DeleteNote(int id)
        {
            var nota = GetNote(id);

            try
            {
                if (nota != null)
                {
                    _context.Notes.Remove(nota);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }

            return false;
        }
    }
}
