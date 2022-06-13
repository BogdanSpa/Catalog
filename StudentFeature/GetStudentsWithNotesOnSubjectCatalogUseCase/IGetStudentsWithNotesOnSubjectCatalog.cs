using EFORM.Models;

namespace StudentFeature.GetStudentsWithNotesOnSubjectCatalogUseCase
{
    public interface IGetStudentsWithNotesOnSubjectCatalog
    {
        IQueryable<GetStudentsWithNotesOnSubjectCatalogResponse> GetStudentsSubjectNotes(GetStudentsWithNotesOnSubjectCatalogRequest model);
    }
}