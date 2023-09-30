using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using webtemplate.Models;
namespace webtemplate.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();
        public StudentController()
        {
            listStudents = new List<Student>() {
            new Student()
            {
                Id = 101,
                Name = "Nguyen Tien Tung",
                Branch = Branch.IT,
                Gender = Gender.Male,
                Address = "Quoc Oai",
                IsRegular = true,
                Email="TungIT^@g.com"
            },
            new Student()
            {
                Id = 102,
                Name = "Nguyen The Trung",
                Branch = Branch.BE,
                Gender = Gender.Male,
                Address = "Hoang Mai",

                Email = "trung@g.com"
            },

            new Student()
            {
                Id = 103,
                Name = "Nhu Duc",
                Branch = Branch.CE,
                Gender = Gender.Male,
                IsRegular = false,
                Address = "Cau Dien",
                Email = "Duc@g.com"
            },

            new Student()
            {
                Id = 104,
                Name = "Vinh",
                Branch = Branch.EE,
                Gender = Gender.Female,
                IsRegular = false,
                Address = "Cau Giay",
                Email = "vinh@g.com"
            }
            };
    }
        [Route("/Admin/Student/Index")]
        public IActionResult Index()
        {
            return View(listStudents);

        }
       [Route("/Admin/Student/Add")]
        [HttpGet("/Admin/Student/Add")]
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
        [HttpPost("/Admin/Student/Add")]
        public IActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                s.Id = listStudents.Last<Student>().Id + 1;
                listStudents.Add(s);
                return View("Index", listStudents);
            }
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
    }
}
