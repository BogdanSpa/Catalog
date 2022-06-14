using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.CatalogFeatureException
{
    public class GetNotesForCatalogInternalServerErrorException : Exception
    {
        public GetNotesForCatalogInternalServerErrorException() : base() { }

        public GetNotesForCatalogInternalServerErrorException(string message) : base(message) { }

        public GetNotesForCatalogInternalServerErrorException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
