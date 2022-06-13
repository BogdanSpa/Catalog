using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.GradeFeatureException
{
    public class SubjectIdDoesNotExistsException : Exception
    {
        public SubjectIdDoesNotExistsException() : base() { }

        public SubjectIdDoesNotExistsException(string message) : base(message) { }

        public SubjectIdDoesNotExistsException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
