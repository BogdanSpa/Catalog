using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.GradeFeatureException
{
    public class InvalidStudentIdException : Exception
    {
        public InvalidStudentIdException() : base() { }

        public InvalidStudentIdException(string message) : base(message) { }

        public InvalidStudentIdException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
