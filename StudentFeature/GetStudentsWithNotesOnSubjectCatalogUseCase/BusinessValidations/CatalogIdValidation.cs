using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeature.GetStudentsWithNotesOnSubjectCatalogUseCase.BusinessValidations
{
    public interface ICatalogIdValidation
    {
        bool Exists(int catalogID);
    }

    public class CatalogIdValidation : ICatalogIdValidation
    {
        private readonly CatalogHomeworkContext _context;

        public CatalogIdValidation(CatalogHomeworkContext context)
        {
            _context = context;
        }

        public bool Exists(int catalogID)
        {
            var catalogEntity = _context.Catalogs.Where(c => c.Id == catalogID).FirstOrDefault();

            if (catalogEntity == null)
            {
                return false;
            }

            return true;
        }
    }
}
