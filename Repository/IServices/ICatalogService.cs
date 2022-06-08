using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IServices
{
    public interface ICatalogService
    {
        bool CreateCatalog(Catalog catalog);
        Catalog GetCatalog(int id);
        Catalog GetCatalog(string clasa);
        bool RemoveCatalog(int id);
        bool UpdateCatalog(Catalog catalog);
    }
}
