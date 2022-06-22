using EFORM.Models;

namespace SubjectFeature.CrudUsecase
{
    public interface ISubjectService
    {
        Task<bool> CreateSubject(SubjectModel subjectModel);
        Task<bool> DeleteSubject(int id);
        Task<Subject> GetSubject(int id);
        Task<bool> UpdateSubject(Subject subject);
    }
}