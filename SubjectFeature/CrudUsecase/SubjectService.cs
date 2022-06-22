
using AutoMapper;
using EFORM.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<SubjectService> _logger;
        public SubjectService(CatalogHomeworkContext context, IMapper mapper, ILogger<SubjectService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> CreateSubject(SubjectModel subjectModel)
        {
            if (subjectModel == null)
                return false;

            Subject subject = _mapper.Map<Subject>(subjectModel);
            try
            {
               await _context.Subjects.AddAsync(subject);
               await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Subject cant be added error: {ex}");
                return false;
            }
        }

        public async Task<Subject> GetSubject(int id)
        {
            return await _context.Subjects.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> UpdateSubject(Subject subject)
        {
            var subjectToBeUpdated = await GetSubject(subject.Id);

            try
            {
                if (subjectToBeUpdated != null)
                {
                    _context.Subjects.Update(subjectToBeUpdated);
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

        public async Task<bool> DeleteSubject(int id)
        {
            var subject = await GetSubject(id);

            try
            {
                if (subject != null)
                {
                    _context.Subjects.Remove(subject);
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
    }
}
