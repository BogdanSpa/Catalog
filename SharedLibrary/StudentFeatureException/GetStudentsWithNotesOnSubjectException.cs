using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.StudentFeatureException
{
    public class GetStudentsWithNotesOnSubjectException : Exception
    {
        public GetStudentsWithNotesOnSubjectException() : base() { }

        public GetStudentsWithNotesOnSubjectException(string message) : base(message) { }

        public GetStudentsWithNotesOnSubjectException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
