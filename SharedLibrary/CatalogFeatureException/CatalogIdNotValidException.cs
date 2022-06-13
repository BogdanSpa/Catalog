using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.CatalogFeatureException
{
    public class CatalogIdNotValidException : Exception
    {
        public CatalogIdNotValidException() : base() { }

        public CatalogIdNotValidException(string message) : base(message) { }

        public CatalogIdNotValidException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
