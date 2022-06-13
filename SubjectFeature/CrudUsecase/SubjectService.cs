
using AutoMapper;
using EFORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectFeature.CrudUsecase
{
    public class SubjectService : ISubjectService
    {
        private readonly CatalogHomeworkContext _context;
        private readonly IMapper _mapper;
        public SubjectService(CatalogHomeworkContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool CreateSubject(SubjectModel subjectModel)
        {
            if (subjectModel == null)
                return false;

            Subject subject = _mapper.Map<Subject>(subjectModel);
            try
            {
                _context.Subjects.Add(subject);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Subject GetSubject(int id)
        {
            return _context.Subjects.FirstOrDefault(s => s.Id == id);
        }

        public bool UpdateSubject(Subject subject)
        {
            var subjectToBeUpdated = _context.Subjects.FirstOrDefault(s => s.Id == subject.Id);

            try
            {
                if (subjectToBeUpdated != null)
                {
                    _context.Subjects.Update(subjectToBeUpdated);
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

        public bool DeleteSubject(int id)
        {
            var subject = GetSubject(id);

            try
            {
                if (subject != null)
                {
                    _context.Subjects.Remove(subject);
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
    }
}
