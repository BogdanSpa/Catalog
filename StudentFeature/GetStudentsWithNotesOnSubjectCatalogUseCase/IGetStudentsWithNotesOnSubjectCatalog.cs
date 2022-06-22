using EFORM.Models;

namespace StudentFeature.GetStudentsWithNotesOnSubjectCatalogUseCase
{
    public interface IGetStudentsWithNotesOnSubjectCatalog
    {
        Task<IEnumerable<GetStudentsWithNotesOnSubjectCatalogResponse>> GetStudentsSubjectNotes(int subjectID, int catalogID);
    }
}