using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.CatalogFeatureException
{
    public class GetAverageForSubjectsInternalServerErrorException : Exception
    {
        public GetAverageForSubjectsInternalServerErrorException() : base() { }

        public GetAverageForSubjectsInternalServerErrorException(string message) : base(message) { }

        public GetAverageForSubjectsInternalServerErrorException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
