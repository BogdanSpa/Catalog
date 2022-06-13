
namespace CatalogFeature.GetAverageForEachSubjectUsecase
{
    public interface IGetAverageForEachSubject
    {
        IEnumerable<GetAverageForEachSubjectModel> GetAverageForSubjects(int catalogID);
    }
}