using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.CatalogFeatureException
{

    public class GetNotesForSubjectInternalServerErrorException : Exception
    {
        public GetNotesForSubjectInternalServerErrorException() : base() { }

        public GetNotesForSubjectInternalServerErrorException(string message) : base(message) { }

        public GetNotesForSubjectInternalServerErrorException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
