using EFORM.Models;
using SubjectFeature.GetAllCatalogsForSubjectUseCase;

namespace SubjectFeature.GetAllCatalogsForSubject
{
    public interface IGetAllCatalogForSubject
    {
        IQueryable<GetAllCatalogsForSubjectResponse> GetAllCatalogsForSubjectId(int id);
    }
}