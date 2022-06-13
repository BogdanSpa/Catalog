using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.StudentFeatureException
{
    public class GetStudentByClassIsInvalidException : Exception
    {
        public GetStudentByClassIsInvalidException() : base() { }

        public GetStudentByClassIsInvalidException(string message) : base(message) { }

        public GetStudentByClassIsInvalidException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
