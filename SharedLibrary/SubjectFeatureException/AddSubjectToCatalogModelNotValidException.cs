using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.SubjectFeatureException
{
    public class AddSubjectToCatalogModelNotValidException : Exception
    {
        public AddSubjectToCatalogModelNotValidException() : base() { }

        public AddSubjectToCatalogModelNotValidException(string message) : base(message) { }

        public AddSubjectToCatalogModelNotValidException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
