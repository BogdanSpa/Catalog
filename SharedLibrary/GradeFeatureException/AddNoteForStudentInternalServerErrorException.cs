using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class AddNoteForStudentInternalServerErrorException : Exception
    {
        public AddNoteForStudentInternalServerErrorException() : base() { }

        public AddNoteForStudentInternalServerErrorException(string message) : base(message) { }

        public AddNoteForStudentInternalServerErrorException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
