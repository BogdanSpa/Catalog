using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogFeature.GetNotesForSubjectByStudentUseCase.BusinessValidations
{
    public interface IStudentIdValidation
    {
        bool Exists(int studentID);
    }

    public class StudentIdValidation : IStudentIdValidation
    {
        private readonly CatalogHomeworkContext _context;

        public StudentIdValidation(CatalogHomeworkContext context)
        {
            _context = context;
        }

        public bool Exists(int studentID)
        {
            var studentEntity = _context.Students.Where(s => s.Id == studentID).FirstOrDefault();

            if (studentEntity == null)
            {
                return false;
            }

            return true;
        }
    }
}
