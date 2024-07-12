using FullStack.Services.Web.Models;

namespace FullStack.Services.Web.Services.IService
{
    public interface IStudentRegister
    {
        Task<ResponseDto> GetAllStudentAsync();
        Task<ResponseDto> GetStudentByNameAsync(string firstName);
        Task<ResponseDto> CreateStudentAsync(StudentDto student);
        Task<ResponseDto> UpdateStudentAsync(StudentDto student);
        Task<ResponseDto> DeleteStudentAsync(int studentId);
    }
}
