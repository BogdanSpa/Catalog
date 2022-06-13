﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.CatalogFeatureException
{
    public class GetNotesForCatalogInternalErrorException : Exception
    {
        public GetNotesForCatalogInternalErrorException() : base() { }

        public GetNotesForCatalogInternalErrorException(string message) : base(message) { }

        public GetNotesForCatalogInternalErrorException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}