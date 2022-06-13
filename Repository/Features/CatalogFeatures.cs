
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFORM.Models;
using Repository.IFeatures;
namespace Repository.Features
{
    public class CatalogFeatures : ICatalogFeatures
    {
        private readonly CatalogHomeworkContext _context;

        public CatalogFeatures(CatalogHomeworkContext context)
        {
            _context = context;
        }

        public IQueryable<Subject> GetSubjectsForCatalog(int idCatalog)
        {
            try
            {
                var query = _context.NoteLists.Where(x => x.CatalogId == idCatalog).Select(x => x.Nota.Materie).Distinct();
                return query;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<Student> GetStudentsByCatalog(int id)
        {
            try
            {
                var query = _context.NoteLists.Where(n => n.CatalogId == id).Select(s => s.Nota.Student).Distinct();
                return query;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IQueryable<GetNotesForCatalogModel> GetNotesForCatalog(int id)
        {
            try
            {
                var query = _context.NoteLists.Where(c => c.CatalogId == id)
                    .Select(n =>
                         new GetNotesForCatalogModel
                         {
                             Materie = n.Nota.Materie.Nume,
                             NotaId = n.NotaId,
                             Student = n.Nota.Student.Nume + n.Nota.Student.Prenume,
                             Nota = n.Nota.Nota
                         });
                return query;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //10
        public IEnumerable<GetAverageForEachSubjectModel> GetAverageForEachSubject(int catalogID)
        {
            var query = _context.NoteLists.Where(c => c.CatalogId == catalogID).Include(m => m.Nota.Materie).Include(s => s.Nota.Student).Select(n => n.Nota);

            var result = query
                .AsEnumerable()
                .GroupBy(g => new { g.Student.Nume, g.Materie })
                .Select(gr => new GetAverageForEachSubjectModel()
                {
                    Student = gr.Key.Nume,
                    Average = gr.Average(n => n.Nota),
                    Subject = gr.Key.Materie.Nume
                });

            return result;
        }

        public IQueryable<GetNotesForSubjectStudentModel> GetNotesForSubjectByStudent(int id)
        {
            var query = _context.Notes.Where(n => n.StudentId == id);

            var result = query.GroupBy(n => n.Materie.Nume,
                (k, c) => new GetNotesForSubjectStudentModel()
                {
                    Subject = k,
                    Notes = c.Select(n => n.Nota).ToList()
                });

            return result;
        }
    }
}
