using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.StudentFeatureException
{
    public class ClassNotAssignedToCatalogException : Exception
    {
        public ClassNotAssignedToCatalogException() : base() { }

        public ClassNotAssignedToCatalogException(string message) : base(message) { }

        public ClassNotAssignedToCatalogException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
