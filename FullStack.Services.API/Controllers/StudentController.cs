using AutoMapper;
using Azure;
using FullStack.Services.API.Data;
using FullStack.Services.API.Model;
using FullStack.Services.API.Model.Dto;
using FullStack.Services.API.Service;
using Microsoft.AspNetCore.Mvc;

namespace FullStack.Services.API.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRegister _studentRegister;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;

        public StudentController(IStudentRegister studentRegister, IMapper mapper)
        {
            _studentRegister = studentRegister;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet("GetAllStudents")]
        public async Task<ActionResult<ResponseDto>> GetAllStudentAsync()
        {
            var students = await _studentRegister.GetAllStudentAsync();
            _response.Result = students;
            return Ok(_response);
        }

        [HttpGet("GetStudentByName/{firstName}")]
        public async Task<ActionResult<ResponseDto>> GetStudentByNameAsync(string firstName)
        {
            var students = await _studentRegister.GetStudentByNameAsync(firstName);
            _response.Result = students;
            return Ok(_response);
        }

        [HttpPost("CreateStudent")]
        public async Task<ActionResult<ResponseDto>> CreateStudentAsync([FromBody] StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            var response = await _studentRegister.CreateStudentAsync(student);
            return Ok(response);
        }

        [HttpPut("UpdateStudent")]
        public async Task<ActionResult<ResponseDto>> UpdateStudentAsync([FromBody] StudentDto studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            var response = await _studentRegister.UpdateStudentAsync(student);
            return Ok(response);
        }

        [HttpDelete("DeleteStudent/{studentId}")]
        public async Task<ActionResult<ResponseDto>> DeleteStudentAsync(int studentId)
        {
            var response = await _studentRegister.DeleteStudentAsync(studentId);
            return Ok(response);
        }
    }
}
