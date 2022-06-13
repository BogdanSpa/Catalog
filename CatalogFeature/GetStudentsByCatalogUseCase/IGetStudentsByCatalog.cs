using EFORM.Models;

namespace CatalogFeature.GetStudentsByCatalogUseCase
{
    public interface IGetStudentsByCatalog
    {
        IQueryable<GetStudentsByCatalogResponse> GetStudents(int catalogID);
    }
}