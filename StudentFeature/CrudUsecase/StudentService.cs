using AutoMapper;
using EFORM.Models;
using Microsoft.EntityFrameworkCore;
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
        public StudentService(CatalogHomeworkContext context, IMapper mapper, ILogger<StudentService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> CreateStudent(StudentModel request)
        {
            if (request == null)
                return false;

            var student = _mapper.Map<Student>(request);

            try
            {
                await _context.Students.AddAsync(student);
                await  _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Can't add student error: {ex}");
                return false;
            }
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            var studentToBeUpdated = await GetStudent(student.Id);

            try
            {
                if (studentToBeUpdated != null)
                {
                    _context.Students.Update(studentToBeUpdated);
                    await _context.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception)
            {

                return true;
            }

            return false;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            var student = await GetStudent(id);

            try
            {
                if (student != null)
                {
                    _context.Students.Remove(student);
                    await _context.SaveChangesAsync();
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
        //public async Task<IQueryable<Student>> GetStudentsByClass(int idCatalog)
        //{

        //    var query = _context.NoteLists.Where(n => n.CatalogId == idCatalog).Select(s => s.Nota.Student).Distinct();
        //    return query;
        //}


    }
}
