using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Features
{
    public class SubjectFeatures : ISubjectFeatures
    {
        private readonly CatalogHomeworkContext _context;

        public SubjectFeatures(CatalogHomeworkContext context)
        {
            _context = context;
        }

        //8
        public IQueryable<Catalog> GetAllCatalogsForSubjectId(int id)
        {
            var query = _context.SubjectCatalogs.Where(m => m.MaterieId == id).Select(m => m.Catalog);

            return query;
        }

        //5
        public void AddSubjectToCatalog(int subjectID, int catalogID)
        {
            SubjectCatalog sc = new SubjectCatalog()
            {
                CatalogId = catalogID,
                MaterieId = subjectID
            };
            try
            {
                _context.SubjectCatalogs.Add(sc);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}