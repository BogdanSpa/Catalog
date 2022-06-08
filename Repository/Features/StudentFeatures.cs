using EFORM.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Features
{
    public class StudentFeatures : IStudentFeatures
    {
        private readonly CatalogHomeworkContext _context;

        public StudentFeatures(CatalogHomeworkContext context)
        {
            _context = context;
        }
        //Ex 1
        public IQueryable<Student> GetStudentsByClass(string clasa)
        {
            try
            {
                var IdCatalogForClass = _context.Catalogs.FirstOrDefault(c => c.Clasa == clasa).Id;

                var query = _context.NoteLists.Where(n => n.CatalogId == IdCatalogForClass).Select(s => s.Nota.Student).Distinct();
                return query;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //7
        public IQueryable<GetNotesForSubjectStudentModel> GetNotesForSubjectByStudent(int id)
        {
            var query = _context.Notes.Where(n => n.StudentId == id);

            var result = query.GroupBy(n => n.Materie.Nume,
                (k, c) => new GetNotesForSubjectStudentModel()
                {
                    Subject = k,
                    Notes = c.Select(s => s.Nota).ToList()
                });

            return result;
        }

        //9
        public IQueryable<Student> GetStudentsWithNotesOnSubjectCatalog(int subjectID, int catalogID)
        {
            var query = _context.NoteLists.Where(c => c.CatalogId == catalogID).Include(s => s.Nota)
                .Where(s => s.Nota.MaterieId == subjectID)
                .Select(s => s.Nota.Student).Distinct();

            return query;
        }
    }
}
