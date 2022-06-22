using EFORM.Models;

namespace CatalogFeature.CrudUsecase
{
    public interface ICatalogService
    {
        Task<bool> CreateCatalog(CatalogModel catalog);
        Task<Catalog> GetCatalogById(int id);
        Task<Catalog> GetCatalogByClass(string clasa);
        Task<bool> RemoveCatalog(int id);
        Task<bool> UpdateCatalog(Catalog catalog);
    }
}