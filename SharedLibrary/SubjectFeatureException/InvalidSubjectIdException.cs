using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.SubjectFeatureException
{
    public class InvalidSubjectIdException : Exception
    {
        public InvalidSubjectIdException() : base() { }

        public InvalidSubjectIdException(string message) : base(message) { }

        public InvalidSubjectIdException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
