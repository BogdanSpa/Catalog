using EFORM.Models;

namespace GradesFeature.CrudUsecase
{
    public interface INoteService
    {
        Task<bool> CreateNote(Note nota);
        Task<bool> DeleteNote(int id);
        Task<Note> GetNote(int id);
        Task<bool> UpdateNote(Student student);
    }
}