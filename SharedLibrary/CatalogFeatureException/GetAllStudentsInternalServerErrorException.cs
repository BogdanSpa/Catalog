using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SharedLibrary.CatalogFeatureException
{
    public class GetAllStudentsInternalServerErrorException : Exception
    {
        public GetAllStudentsInternalServerErrorException() : base() { }

        public GetAllStudentsInternalServerErrorException(string message) : base(message) { }

        public GetAllStudentsInternalServerErrorException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
