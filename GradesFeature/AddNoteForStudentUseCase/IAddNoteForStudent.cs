namespace GradesFeature.AddNoteForStudentUseCase
{
    public interface IAddNoteForStudent
    {
        Task<bool> AddNote(AddNoteForStudentModel request);
    }
}