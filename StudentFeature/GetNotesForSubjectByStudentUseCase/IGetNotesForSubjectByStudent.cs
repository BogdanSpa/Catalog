
namespace StudentFeature.GetNotesForSubjectByStudentUseCase
{
    public interface IGetNotesForSubjectByStudent
    {
        IQueryable<GetNotesForSubjectStudentModel> GetNotesForSubjectByStudentId(int studentID);
    }
}