using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    public class DepartmentController : Controller
    {

        DepartmentModel depObj = new DepartmentModel();

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Adddepartment(DepartmentModel dep)
        {
            bool res;
            depObj = new DepartmentModel();
            res = depObj.Insertdep(dep);
            if (res)
            {
                TempData["msg"] = "Department added successfully";
            }
            else
            {
                TempData["msg"] = "Department not added";
            }
            return View();
        }
        public IActionResult Adddepartment()
        {
            return View();
        }

        public IActionResult Listofdep()
        {
            depObj = new DepartmentModel();
            List<DepartmentModel> lst = depObj.getData();
            return View(lst);
        }
    }
}
