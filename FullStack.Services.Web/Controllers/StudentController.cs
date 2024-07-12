using FullStack.Services.Web.Models;
using FullStack.Services.Web.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace FullStack.Services.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRegister _studentRegister;

        public StudentController(IStudentRegister studentRegister)
        {
            _studentRegister = studentRegister;
        }

        public async Task<IActionResult> Index()
        {
			List<StudentDto>? list = new();
			ResponseDto? response = await _studentRegister.GetAllStudentAsync();

			if (response != null && response.ISSuccess)
			{
				list = JsonConvert.DeserializeObject<List<StudentDto>>(Convert.ToString(response.Result));
			}
			else
			{
				TempData["error"] = response?.Message;
			}

			return View(list);
		}
    }
}
