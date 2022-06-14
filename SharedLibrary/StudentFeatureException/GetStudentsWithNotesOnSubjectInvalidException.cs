using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.StudentFeatureException
{
    public class GetStudentsWithNotesOnSubjectInvalidException : Exception
    {
        public GetStudentsWithNotesOnSubjectInvalidException() : base() { }

        public GetStudentsWithNotesOnSubjectInvalidException(string message) : base(message) { }

        public GetStudentsWithNotesOnSubjectInvalidException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
