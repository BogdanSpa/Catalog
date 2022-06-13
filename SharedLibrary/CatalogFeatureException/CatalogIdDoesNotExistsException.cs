using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.CatalogFeatureException
{
    public class CatalogIdDoesNotExistsException : Exception
    {
        public CatalogIdDoesNotExistsException() : base() { }

        public CatalogIdDoesNotExistsException(string message) : base(message) { }

        public CatalogIdDoesNotExistsException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
