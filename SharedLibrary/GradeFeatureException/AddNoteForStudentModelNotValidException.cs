using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.GradeFeatureException
{
    public class AddNoteForStudentModelNotValidException : Exception
    {
        public AddNoteForStudentModelNotValidException() : base() { }

        public AddNoteForStudentModelNotValidException(string message) : base(message) { }

        public AddNoteForStudentModelNotValidException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
