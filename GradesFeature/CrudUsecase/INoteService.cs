using EFORM.Models;

namespace GradesFeature.CrudUsecase
{
    public interface INoteService
    {
        bool CreateNote(Note nota);
        bool DeleteNote(int id);
        Note GetNote(int id);
        bool UpdateNote(Student student);
    }
}