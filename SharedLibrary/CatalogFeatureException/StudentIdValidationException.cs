using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SharedLibrary.CatalogFeatureException
{
    public class StudentIdValidationException : Exception
    {
        public StudentIdValidationException() : base() { }

        public StudentIdValidationException(string message) : base(message) { }

        public StudentIdValidationException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
