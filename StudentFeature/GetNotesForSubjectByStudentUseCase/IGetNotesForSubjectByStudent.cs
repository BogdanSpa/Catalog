
namespace StudentFeature.GetNotesForSubjectByStudentUseCase
{
    public interface IGetNotesForSubjectByStudent
    {
        Task <IEnumerable<GetNotesForSubjectStudentModel>> GetNotesForSubjectByStudentId(int studentID);
    }
}