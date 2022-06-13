using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.CatalogFeatureException
{
    public class GetSubjectsForCatalogInternalServerErrorException : Exception
    {
        public GetSubjectsForCatalogInternalServerErrorException() : base() { }

        public GetSubjectsForCatalogInternalServerErrorException(string message) : base(message) { }

        public GetSubjectsForCatalogInternalServerErrorException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
