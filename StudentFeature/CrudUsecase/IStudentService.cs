using EFORM.Models;

namespace StudentFeature.CrudUsecase
{
    public interface IStudentService
    {
        Task<bool> CreateStudent(StudentModel request);
        Task<bool> DeleteStudent(int id);
        Task<Student> GetStudent(int id);
       // IQueryable<Student> GetStudentsByClass(int idCatalog);
        Task<bool> UpdateStudent(Student student);
    }
}