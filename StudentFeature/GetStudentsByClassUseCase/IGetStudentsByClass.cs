using EFORM.Models;
using StudentFeature.GetStudentsByClassUseCase;

namespace StudentFeature.GetStudentByClassUseCase
{
    public interface IGetStudentsByClass
    {
        IEnumerable<GetStudentsByClassResponse> GetStudentsOnClass(string clasa);
    }
}