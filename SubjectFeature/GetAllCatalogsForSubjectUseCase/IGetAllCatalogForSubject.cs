using EFORM.Models;
using SubjectFeature.GetAllCatalogsForSubjectUseCase;

namespace SubjectFeature.GetAllCatalogsForSubject
{
    public interface IGetAllCatalogForSubject
    {
        IEnumerable<GetAllCatalogsForSubjectResponse> GetAllCatalogsForSubjectId(int id);
    }
}