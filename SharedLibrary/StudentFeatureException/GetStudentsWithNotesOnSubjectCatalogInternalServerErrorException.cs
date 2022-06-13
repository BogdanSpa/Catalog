using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.StudentFeatureException
{
    public class GetStudentsWithNotesOnSubjectCatalogInternalServerErrorException : Exception
    {
        public GetStudentsWithNotesOnSubjectCatalogInternalServerErrorException() : base() { }

        public GetStudentsWithNotesOnSubjectCatalogInternalServerErrorException(string message) : base(message) { }

        public GetStudentsWithNotesOnSubjectCatalogInternalServerErrorException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
