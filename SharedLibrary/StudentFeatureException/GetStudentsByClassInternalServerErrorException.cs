using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.StudentFeatureException
{
    public class GetStudentsByClassInternalServerErrorException : Exception
    {
        public GetStudentsByClassInternalServerErrorException() : base() { }

        public GetStudentsByClassInternalServerErrorException(string message) : base(message) { }

        public GetStudentsByClassInternalServerErrorException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
