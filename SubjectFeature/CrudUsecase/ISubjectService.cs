using EFORM.Models;

namespace SubjectFeature.CrudUsecase
{
    public interface ISubjectService
    {
        bool CreateSubject(SubjectModel subjectModel);
        bool DeleteSubject(int id);
        Subject GetSubject(int id);
        bool UpdateSubject(Subject subject);
    }
}