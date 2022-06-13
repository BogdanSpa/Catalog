using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.CatalogFeatureException
{

    public class GetNotesForSubjectInternalServerError : Exception
    {
        public GetNotesForSubjectInternalServerError() : base() { }

        public GetNotesForSubjectInternalServerError(string message) : base(message) { }

        public GetNotesForSubjectInternalServerError(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
