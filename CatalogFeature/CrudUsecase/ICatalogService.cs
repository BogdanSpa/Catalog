using EFORM.Models;

namespace CatalogFeature.CrudUsecase
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