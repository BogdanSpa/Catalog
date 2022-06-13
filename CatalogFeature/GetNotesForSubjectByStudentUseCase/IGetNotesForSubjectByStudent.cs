
namespace CatalogFeature.GetNotesForSubjectByStudentUseCase
{
    public interface IGetNotesForSubjectByStudent
    {
        IQueryable<GetNotesForSubjectStudentModel> GetNotes(int id);
    }
}