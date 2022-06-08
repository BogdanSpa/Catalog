using EFORM.Models;
using Repository.Models;

namespace Repository.IFeatures
{
    public interface IStudentFeatures
    {
        IQueryable<GetNotesForSubjectStudentModel> GetNotesForSubjectByStudent(int id);
        IQueryable<Student> GetStudentsByClass(string clasa);
        IQueryable<Student> GetStudentsWithNotesOnSubjectCatalog(int subjectID, int catalogID);
    }
}