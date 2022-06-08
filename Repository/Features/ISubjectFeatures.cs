using EFORM.Models;

namespace Repository.Features
{
    public interface ISubjectFeatures
    {
        void AddSubjectToCatalog(int subjectID, int catalogID);
        IQueryable<Catalog> GetAllCatalogsForSubjectId(int id);
    }
}