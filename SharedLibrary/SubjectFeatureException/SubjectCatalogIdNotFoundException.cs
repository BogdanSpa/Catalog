using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.SubjectFeatureException
{
    public class SubjectCatalogIdNotFoundException : Exception
    {
        public SubjectCatalogIdNotFoundException() : base() { }

        public SubjectCatalogIdNotFoundException(string message) : base(message) { }

        public SubjectCatalogIdNotFoundException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
