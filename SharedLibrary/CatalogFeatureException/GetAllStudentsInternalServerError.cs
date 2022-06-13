using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SharedLibrary.CatalogFeatureException
{
    public class GetAllStudentsInternalServerError : Exception
    {
        public GetAllStudentsInternalServerError() : base() { }

        public GetAllStudentsInternalServerError(string message) : base(message) { }

        public GetAllStudentsInternalServerError(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
