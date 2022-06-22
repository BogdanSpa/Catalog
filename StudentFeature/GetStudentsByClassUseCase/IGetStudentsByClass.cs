using EFORM.Models;
using StudentFeature.GetStudentsByClassUseCase;

namespace StudentFeature.GetStudentByClassUseCase
{
    public interface IGetStudentsByClass
    {
        Task<IEnumerable<GetStudentsByClassResponse>> GetStudentsOnClass(string clasa);
    }
}