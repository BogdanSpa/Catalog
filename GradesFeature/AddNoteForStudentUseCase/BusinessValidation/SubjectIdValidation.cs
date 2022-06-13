﻿using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesFeature.AddNoteForStudentUseCase.BusinessValidation
{
    public interface ISubjectIdValidation
    {
        bool Exists(int catalogID);
    }

    public class SubjectIdValidation : ISubjectIdValidation
    {
        private readonly CatalogHomeworkContext _context;

        public SubjectIdValidation(CatalogHomeworkContext context)
        {
            _context = context;
        }

        public bool Exists(int subjectID)
        {
            var subjectEntity = _context.Subjects.Where(s => s.Id == subjectID).FirstOrDefault();

            if (subjectEntity == null)
            {
                return false;
            }
            return true;
        }
    }
}