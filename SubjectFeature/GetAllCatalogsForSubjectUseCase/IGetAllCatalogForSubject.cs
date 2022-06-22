using EFORM.Models;
using SubjectFeature.GetAllCatalogsForSubjectUseCase;

namespace SubjectFeature.GetAllCatalogsForSubject
{
    public interface IGetAllCatalogForSubject
    {
        Task<IEnumerable<GetAllCatalogsForSubjectResponse>> GetAllCatalogsForSubjectId(int id);
    }
}