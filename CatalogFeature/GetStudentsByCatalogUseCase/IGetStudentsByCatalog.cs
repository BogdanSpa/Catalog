using EFORM.Models;

namespace CatalogFeature.GetStudentsByCatalogUseCase
{
    public interface IGetStudentsByCatalog
    {
        IEnumerable<GetStudentsByCatalogResponse> GetStudents(int catalogID);
    }
}