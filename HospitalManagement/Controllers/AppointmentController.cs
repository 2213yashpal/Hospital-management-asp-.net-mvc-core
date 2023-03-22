using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    public class AppointmentController : Controller
    {
        AppointmentModel appObj = new AppointmentModel();
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Addappointment(AppointmentModel appointments)
        {
            bool res;
            appObj = new AppointmentModel();
            res = appObj.addappointment(appointments);
            if (res)
            {
                TempData["msg"] = "appoinment added successfully";
            }
            else
            {
                TempData["msg"] = "appoinment not added";
            }
            return View();
        }

        public IActionResult Addappointment()
        {
            return View();
        }


        public IActionResult Listofactiveappointment()
        {
            appObj = new AppointmentModel();
            List<AppointmentModel> lst = appObj.getData();
            return View(lst);
        }

        public IActionResult Listofpendingappointment()
        {
            appObj = new AppointmentModel();
            List<AppointmentModel> lst = appObj.getDatapending();
            return View(lst);
        }

        [HttpGet]
        public IActionResult editapp(string Id)
        {
            AppointmentModel app = appObj.getData(Id);
            return View(app);
        }

        [HttpPost]
        public IActionResult editapp(AppointmentModel app)
        {
            bool res;

            appObj = new AppointmentModel();
            res = appObj.update(app);
            if (res)
            {
                TempData["msg"] = "Updated successfully";
            }
            else
            {
                TempData["msg"] = "Not Updated. something went wrong..!!";
            }
            return View();
        }

        [HttpGet]
        public IActionResult deleteapp(string Id)
        {
            AppointmentModel app = appObj.getData(Id);
            return View(app);
        }

        [HttpPost]
        public IActionResult deleteapp(AppointmentModel app)
        {
            bool res;

            appObj = new AppointmentModel();
            res = appObj.delete(app);
            if (res)
            {
                TempData["msg"] = "Deleted successfully";
            }
            else
            {
                TempData["msg"] = "Not Deleted. something went wrong..!!";
            }
            return View();
        }
    }
}

