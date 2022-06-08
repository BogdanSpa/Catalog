using EFORM.Models;
using Repository.Features;
using Repository.Models;

namespace Repository.IFeatures
{
    public interface ICatalogFeatures
    {
        IEnumerable<GetAverageForEachSubjectModel> GetAverageForEachSubject(int catalogID);
        IQueryable<GetNotesForCatalogModel> GetNotesForCatalog(int id);
        IQueryable<GetNotesForSubjectStudentModel> GetNotesForSubjectByStudent(int id);
        IQueryable<Student> GetStudentsByCatalog(int id);
        IQueryable<Subject> GetSubjectsForCatalog(int idCatalog);
    }
}