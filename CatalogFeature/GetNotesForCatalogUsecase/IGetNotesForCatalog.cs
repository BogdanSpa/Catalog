
namespace CatalogFeature.GetNotesForCatalogUsecase
{
    public interface IGetNotesForCatalog
    {
        IQueryable<GetNotesForCatalogModel> GetNotes(int id);
    }
}