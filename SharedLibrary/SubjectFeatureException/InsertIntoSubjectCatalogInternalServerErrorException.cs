using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.SubjectFeatureException
{
    public class InsertIntoSubjectCatalogInternalServerErrorException : Exception
    {
        public InsertIntoSubjectCatalogInternalServerErrorException() : base() { }

        public InsertIntoSubjectCatalogInternalServerErrorException(string message) : base(message) { }

        public InsertIntoSubjectCatalogInternalServerErrorException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
