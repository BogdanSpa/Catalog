namespace SubjectFeature.AddSubjectToCatalogUseCase
{
    public interface IAddSubjectToCatalog
    {
        Task<bool> AddSubjectToTheCatalog(AddSubjectToCatalogModel model);
    }
}