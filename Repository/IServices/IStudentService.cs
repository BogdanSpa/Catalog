using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IServices
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
