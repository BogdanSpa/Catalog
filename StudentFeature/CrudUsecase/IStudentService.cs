using EFORM.Models;

namespace StudentFeature.CrudUsecase
{
    public interface IStudentService
    {
        bool CreateStudent(StudentModel student);
        bool DeleteStudent(int id);
        Student GetStudent(int id);
        IQueryable<Student> GetStudentsByClass(int idCatalog);
        bool UpdateStudent(Student student);
    }
}