using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.StudentFeatureException
{
    public class StudentNotFoundForStudentIdException : Exception
    {
        public StudentNotFoundForStudentIdException() : base() { }

        public StudentNotFoundForStudentIdException(string message) : base(message) { }

        public StudentNotFoundForStudentIdException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
