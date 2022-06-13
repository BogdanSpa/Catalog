using EFORM.Models;

namespace StudentFeature.GetStudentsWithNotesOnSubjectCatalogUseCase
{
    public interface IGetStudentsWithNotesOnSubjectCatalog
    {
        IEnumerable<GetStudentsWithNotesOnSubjectCatalogResponse> GetStudentsSubjectNotes(int subjectID, int catalogID);
    }
}