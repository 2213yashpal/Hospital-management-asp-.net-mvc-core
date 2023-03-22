using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    public class MedicineController : Controller
    {
        MedicineModel medObj = new MedicineModel();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listofmedicine()
        {

            medObj = new MedicineModel();
            List<MedicineModel> lst = medObj.getData();
            return View(lst);
        }


        [HttpPost]
        public IActionResult Addmedicine(MedicineModel med)
        {
            bool res;
            medObj = new MedicineModel();
            res = medObj.Insertmed(med);
            if (res)
            {
                TempData["msg"] = "Medicine added successfully";
            }
            else
            {
                TempData["msg"] = "Medicine not added";
            }
            return View();
        }
        public IActionResult Addmedicine()
        {
            return View();
        }
    }
}
