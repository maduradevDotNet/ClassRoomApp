using FullStack.Services.API.Data;
using FullStack.Services.API.Model;
using FullStack.Services.API.Model.Dto;
using Microsoft.EntityFrameworkCore;

namespace FullStack.Services.API.Service
{
    public class StudentRegister : IStudentRegister
    {
        private readonly AppDbContext _dbContext;
        private readonly ResponseDto _response;

        public StudentRegister(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _response = new ResponseDto();
        }

        public async Task<ResponseDto> CreateStudentAsync(Student student)
        {
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
            _response.Result = student;
            _response.Message = "Student created successfully.";
            return _response;
        }

        public async Task<ResponseDto> DeleteStudentAsync(int studentId)
        {
            var student = await _dbContext.Students.FindAsync(studentId);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync();
                _response.Result = student;
                _response.Message = "Student deleted successfully.";
            }
            else
            {
                _response.ISSuccess = false;
                _response.Message = "Student not found.";
            }
            return _response;
        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<List<Student>> GetStudentByNameAsync(string firstName)
        {
            var students = await _dbContext.Students
                .Where(s => s.FirstName.Contains(firstName))
                .ToListAsync();
            return students;
        }

        public async Task<ResponseDto> UpdateStudentAsync(Student student)
        {
            var existingStudent = await _dbContext.Students.FindAsync(student.StudentId);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Age = student.Age;
                existingStudent.EnrollmentDate = student.EnrollmentDate;

                _dbContext.Students.Update(existingStudent);
                await _dbContext.SaveChangesAsync();
                _response.Result = existingStudent;
                _response.Message = "Student updated successfully.";
            }
            else
            {
                _response.ISSuccess = false;
                _response.Message = "Student not found.";
            }
            return _response;
        }
    }
}
