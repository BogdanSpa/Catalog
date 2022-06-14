using AutoMapper;
using EFORM.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFeature.CrudUsecase
{
    public class StudentService : IStudentService
    {
        private readonly CatalogHomeworkContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<StudentService> _logger;
        public StudentService(CatalogHomeworkContext context)
        {
            _context = context;
        }

        public bool CreateStudent(StudentModel request)
        {
            if (request == null)
                return false;

            var student = _mapper.Map<Student>(request);

            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Can't add student error: {ex}");
                return false;
            }
        }

        public Student GetStudent(int id)
        {
            return _context.Students.FirstOrDefault(s => s.Id == id);
        }

        public bool UpdateStudent(Student student)
        {
            var studentToBeUpdated = _context.Students.FirstOrDefault(s => s.Id == student.Id);

            try
            {
                if (studentToBeUpdated != null)
                {
                    _context.Students.Update(studentToBeUpdated);
                    _context.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {

                return true;
            }

            return false;
        }

        public bool DeleteStudent(int id)
        {
            var student = GetStudent(id);

            try
            {
                if (student != null)
                {
                    _context.Students.Remove(student);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return false;
        }

        //Ex 1
        public IQueryable<Student> GetStudentsByClass(int idCatalog)
        {

            var query = _context.NoteLists.Where(n => n.CatalogId == idCatalog).Select(s => s.Nota.Student).Distinct();
            return query;
        }


    }
}
