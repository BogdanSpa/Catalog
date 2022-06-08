namespace Repository.Features
{
    public interface INoteFeatures
    {
        void AddNoteForStudentId(int studentId, int materieId, byte note, int catalogId);
    }
}