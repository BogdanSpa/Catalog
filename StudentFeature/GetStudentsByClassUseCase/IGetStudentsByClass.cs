using EFORM.Models;
using StudentFeature.GetStudentsByClassUseCase;

namespace StudentFeature.GetStudentByClassUseCase
{
    public interface IGetStudentsByClass
    {
        IQueryable<GetStudentsByClassResponse> GetStudentsOnClass(string clasa);
    }
}