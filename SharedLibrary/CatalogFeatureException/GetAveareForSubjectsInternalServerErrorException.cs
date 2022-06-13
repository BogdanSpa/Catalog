using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.CatalogFeatureException
{
    public class GetAveareForSubjectsInternalServerErrorException : Exception
    {
        public GetAveareForSubjectsInternalServerErrorException() : base() { }

        public GetAveareForSubjectsInternalServerErrorException(string message) : base(message) { }

        public GetAveareForSubjectsInternalServerErrorException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
