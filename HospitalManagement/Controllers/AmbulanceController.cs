using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    public class AmbulanceController : Controller
    {
        AmbulanceModel ambObj = new AmbulanceModel();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Addambulance(AmbulanceModel ambulance)
        {
            bool res;
            ambObj = new AmbulanceModel();
            res = ambObj.Insertambulance(ambulance);
            if (res)
            {
                TempData["msg"] = "Ambulance added successfully";
            }
            else
            {
                TempData["msg"] = "Ambulance not added";
            }
            return View();
        }
        public IActionResult Addambulance()
        {
            return View();
        }

       
        public IActionResult Listofambulance()
        {
            ambObj = new AmbulanceModel();
            List<AmbulanceModel> lst = ambObj.getData();
            return View(lst);
        }
    }
}
