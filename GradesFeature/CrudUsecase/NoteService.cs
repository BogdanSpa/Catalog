using EFORM.Models;
using Microsoft.EntityFrameworkCore;
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
        public async Task<bool> CreateNote(Note nota)
        {
            if (nota == null)
                return false;

            try
            {
                await _context.Notes.AddAsync(nota);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Note> GetNote(int id)
        {
            return await _context.Notes.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> UpdateNote(Student student)
        {
            var noteToBeUpdated = await _context.Notes.FirstOrDefaultAsync(s => s.Id == student.Id);

            try
            {
                if (noteToBeUpdated != null)
                {
                    _context.Notes.Update(noteToBeUpdated);
                    await _context.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception)
            {

                return true;
            }

            return false;
        }

        public async Task<bool> DeleteNote(int id)
        {
            var nota = await GetNote(id);

            try
            {
                if (nota != null)
                {
                    _context.Notes.Remove(nota);
                    await _context.SaveChangesAsync();
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
