using EFORM.Models;

namespace CatalogFeature.GetSubjectsForCatalogUseCase
{
    public interface IGetSubjectsForCatalog
    {
        IQueryable<GetSubjectForCatalogResponse> GetSubjects(int catalogID);
    }
}