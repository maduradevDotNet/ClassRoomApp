using FullStack.Services.API.Model;
using FullStack.Services.API.Model.Dto;

namespace FullStack.Services.API.Service
{
    public interface IStudentRegister
    {

        Task<List<Student>> GetAllStudentAsync();
        Task<List<Student>> GetStudentByNameAsync(string firstName);
        Task<ResponseDto> CreateStudentAsync(Student student);
        Task<ResponseDto> UpdateStudentAsync(Student student);
        Task<ResponseDto> DeleteStudentAsync(int studentId);
    }
}
