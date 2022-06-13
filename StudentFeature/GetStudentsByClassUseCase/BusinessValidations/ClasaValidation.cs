using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeature.GetStudentsByClassUseCase.BusinessValidations
{
    public interface IClasaValidation
    {
        bool Exists(string clasa);
    }

    public class ClasaValidation : IClasaValidation
    {
        private readonly CatalogHomeworkContext _context;

        public ClasaValidation(CatalogHomeworkContext context)
        {
            _context = context;
        }

        public bool Exists(string clasa)
        {
            var catalogEntity = _context.Catalogs.Where(c => c.Clasa == clasa).FirstOrDefault();

            if (catalogEntity == null)
            {
                return false;
            }

            return true;
        }
    }
}
