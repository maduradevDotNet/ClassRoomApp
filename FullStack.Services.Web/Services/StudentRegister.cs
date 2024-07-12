using FullStack.Services.Web.Models;
using FullStack.Services.Web.Services.IService;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using FullStack.Services.Web.Utility;

namespace FullStack.Services.Web.Services
{
    public class StudentRegister : IStudentRegister
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<StudentRegister> _logger;

        public StudentRegister(HttpClient httpClient, ILogger<StudentRegister> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ResponseDto> CreateStudentAsync(StudentDto student)
        {
            var response = await _httpClient.PostAsJsonAsync($"{SD.StudentApiBase}/api/students", student);
            return await HandleApiResponse(response);
        }

        public async Task<ResponseDto> DeleteStudentAsync(int studentId)
        {
            var response = await _httpClient.DeleteAsync($"{SD.StudentApiBase}/api/students/{studentId}");
            return await HandleApiResponse(response);
        }

        public async Task<ResponseDto> GetAllStudentAsync()
        {
            var response = await _httpClient.GetAsync($"{SD.StudentApiBase}/api/students");
            return await HandleApiResponse(response);
        }

        public async Task<ResponseDto> GetStudentByNameAsync(string firstName)
        {
            var response = await _httpClient.GetAsync($"{SD.StudentApiBase}/api/students?firstName={firstName}");
            return await HandleApiResponse(response);
        }

        public async Task<ResponseDto> UpdateStudentAsync(StudentDto student)
        {
            var response = await _httpClient.PutAsJsonAsync($"{SD.StudentApiBase}/api/students/{student.StudentId}", student);
            return await HandleApiResponse(response);
        }

        private async Task<ResponseDto> HandleApiResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"API call failed with status code {response.StatusCode}");
                return new ResponseDto { ISSuccess = false, Message = "API call failed" };
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"API response: {responseContent}");

            if (string.IsNullOrEmpty(responseContent))
            {
                _logger.LogError("Received empty response from API");
                return new ResponseDto { ISSuccess = false, Message = "Received empty response from API" };
            }

            try
            {
                var apiResponse = System.Text.Json.JsonSerializer.Deserialize<ResponseDto>(responseContent);
                return apiResponse ?? new ResponseDto { ISSuccess = false, Message = "Invalid response from API" };
            }
            catch (System.Text.Json.JsonException ex)
            {
                _logger.LogError($"Failed to deserialize API response: {ex.Message}");
                return new ResponseDto { ISSuccess = false, Message = "Failed to deserialize API response" };
            }
        }
    }
}
