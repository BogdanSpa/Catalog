using EFORM.Models;

namespace StudentFeature.CrudUsecase
{
    public interface IStudentService
    {
        bool CreateStudent(Student student);
        bool DeleteStudent(int id);
        Student GetStudent(int id);
        IQueryable<Student> GetStudentsByClass(int idCatalog);
        bool UpdateStudent(Student student);
    }
}