using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BTTH3.Models;

namespace BTTH3.Controllers
{
    public class StudentController : Controller
    {
        // Khai báo danh sách sinh viên giả lập để lưu trữ dữ liệu tạm thời
        private static List<Student> listStudents = new List<Student>();

        // 1. Action GET: Hiển thị giao diện Form Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };

            return View();
        }

        // 2. Action POST: Nhận dữ liệu khi người dùng bấm nút Create trên form
        [HttpPost]
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                // Tự động tăng ID cho sinh viên
                int nextId = listStudents.Count > 0 ? listStudents.Last<Student>().Id + 1 : 1;
                s.Id = nextId;

                listStudents.Add(s);
                return View("Index", listStudents);
            }

            // Nếu dữ liệu không hợp lệ, load lại ViewBag để hiển thị lại form kèm lỗi
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();

            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };

            return View();
        }

        // Action hiển thị danh sách sau khi tạo thành công
        public IActionResult Index()
        {
            return View(listStudents);
        }
    }
}