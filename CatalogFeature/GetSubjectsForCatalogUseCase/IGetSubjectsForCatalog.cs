using EFORM.Models;

namespace CatalogFeature.GetSubjectsForCatalogUseCase
{
    public interface IGetSubjectsForCatalog
    {
        IEnumerable<GetSubjectForCatalogResponse> GetSubjects(int catalogID);
    }
}